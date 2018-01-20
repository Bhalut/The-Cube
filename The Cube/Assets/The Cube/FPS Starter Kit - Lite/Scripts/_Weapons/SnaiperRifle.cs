using UnityEngine;
using System.Collections;

public class SnaiperRifle : MonoBehaviour
{
    public Transform camera1;// fpc camera
    public Transform metalHit;// texture of holes from bullets
    public Transform MetalSparks;// sparks from bullet
    public Transform MuzzleFlash;// fire shoot
    public Light Light;// light when shoot
    private RaycastHit Hit;// raycast ray
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;
    public int curAmmo = 0;// curent ammo
    public int maxAmmo = 12;// max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    public bool aim;// can aim
    private float timeout = 0.2f;// timer
    public float Accuracy = 0.01f;//accuracy of bullets
    public AudioClip Shoot;   // audio
    public AudioClip Reloaded;//
    public GUIText bulletGUI;// text which shows the current ammo
    public int svumode;//animation mode
    private float svureload;
    private float svuAim;
    public GameObject blaster;//sniper rifle model
    public int damage;// robots damage

    public AnimationClip _Idle;  //
    public AnimationClip _Reload;//
    public AnimationClip _Shoot; //Aniations
    public AnimationClip _AimOn; //
    public AnimationClip _AimOff;//
    string _idle_;
    string _reload_;
    string _shoot_;
    string _ON_;
    string _OFF_;

    void Update()
    {
        _ON_ = _AimOn.name;     //
        _OFF_ = _AimOff.name;   //
        _idle_ = _Idle.name;    //
        _reload_ = _Reload.name;//
        _shoot_ = _Shoot.name;  //

        //start animation


        if (svumode == 0)
        {
            GetComponent<Animation>().CrossFade(_idle_);// idle animation

        }
        //Reload
        if (svumode == 4)
        {
            blaster.SetActive(true);//deactivation sniper rifle
            GetComponent<Animation>().CrossFade(_reload_);// reload animation
            svureload += Time.deltaTime;
            AimOff();
        }
        if (svureload >= GetComponent<Animation>()[_reload_].length)
        {
            Reload();
            svumode = 0;// animation mode
            svureload = 0;
        }
        if (svumode == 5)
        {
            GetComponent<Animation>().Play(_ON_, PlayMode.StopAll);
            svuAim += Time.deltaTime;
        }
        if (svuAim >= GetComponent<Animation>()[_ON_].length)// aim on animation
        {
            Aim();
            svuAim = 0;
            blaster.SetActive(false);//deactivation sniper rifle
        }
        if (svumode == 6)
        {
            GetComponent<Animation>().Play(_OFF_, PlayMode.StopAll);
            svuAim += Time.deltaTime;
        }

        if (svuAim >= GetComponent<Animation>()[_OFF_].length)// aim off animation
        {
            AimOff();
            svumode = 0;// animation mode
            svuAim = 0;
            blaster.SetActive(true);//activation sniper rifle
        }


        //end animation


        if (_rateofSpeed <= RateOfSpeed)//rate of shoot
        {
            _rateofSpeed += Time.deltaTime;
        }
        if (timeout < 0.1f & aim == false)// light timer
        {
            timeout += Time.deltaTime;
            Light.range = 15;
        }
        else
        {
            Light.range = 0;
        }
		if (Input.GetButtonDown("Attack") & _rateofSpeed > RateOfSpeed & svumode != 4 & svumode != 6 & curAmmo > 0)// if shoot
        {
            timeout = 0;
            curAmmo -= 1;//ammo consumption
            _rateofSpeed = 0;
            GetComponent<AudioSource>().PlayOneShot(Shoot);// play audio
            GetComponent<Animation>().Play(_shoot_, PlayMode.StopAll);// shoot animation
            Vector3 Direction = camera1.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));//accuracy of bullet
            if (aim == false)
            {
                MuzzleFlash.GetComponent<ParticleEmitter>().emit = true;
            }
            if (Physics.Raycast(camera1.position, Direction, out Hit, 10000f))// create raycast ray
            {

                if (Hit.collider.CompareTag("Robot"))//If ray hit robot
                {
					Hit.collider.GetComponent<Robot_Destroy>().Robot_health -= Hit.collider.GetComponent<Robot_Destroy>().sniperrifle_damage;// robot health - damage
                }
                Quaternion HitRotation = Quaternion.FromToRotation(Vector3.up, Hit.normal);// create bullet hole
                if (Hit.transform.GetComponent<Rigidbody>())// if ray hit rigidbody object
                {
                    Hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 800, Hit.point);// object push
                }
                if (Hit.collider.material.staticFriction == 0.2f)
                {
                    Transform metalhitGO = Instantiate(metalHit, Hit.point + (Hit.normal * 0.001f), HitRotation) as Transform;//
                    metalhitGO.transform.parent = Hit.transform;                                                              // create sparks
                    Instantiate(MetalSparks, Hit.point + (Hit.normal * 0.01f), HitRotation);                                  //
                }
            }
        }
        else
        {
            MuzzleFlash.GetComponent<ParticleEmitter>().emit = false;
        }
		if (Input.GetButtonDown("Reload") & inventoryAmmo > 0 & curAmmo != maxAmmo)// if reload
        {
            GetComponent<AudioSource>().PlayOneShot(Reloaded, 0.7f);// play audio
            svumode = 4;// animation mode
        }
		if (Input.GetButtonDown("Aim") & aim == false & svumode == 0)// if aim on
        {
            svumode = 5;// animation mode
        }
		if (Input.GetButtonDown("Aim") & aim == true)// if aim off
        {
            svumode = 6;// animation mode
        }

        if (aim == true)
        {
			GetComponent<SnaiperRifle_AimControl>().enabled = true;//draw aim = true
        }
        else
        {
			GetComponent<SnaiperRifle_AimControl>().enabled = false;//draw aim = false
        }
    }


    public void Reload()//ammo calculation
    {

        if (inventoryAmmo < maxAmmo - curAmmo)
        {
            curAmmo += inventoryAmmo;
            inventoryAmmo = 0;
        }
        else
        {
            inventoryAmmo -= maxAmmo - curAmmo;
            curAmmo += maxAmmo - curAmmo;
        }
    }
    public void Aim()

    {

        aim = true;
        camera1.GetComponent<Camera>().fieldOfView = 30;// camera depth = 30
        camera1.GetComponent<Camera>().depth = 2;
		camera1.GetComponent<MouseLook> ().sensitivityX = 3;//sensitivity change
		camera1.GetComponent<MouseLook> ().sensitivityY = 3;//sensitivity change
		GameObject.FindWithTag ("Player").GetComponent<MouseLook>().sensitivityX=3;//sensitivity change
    }

    public void AimOff()
    {
        aim = false;
        camera1.GetComponent<Camera>().fieldOfView = 60;// camera depth = 60
        camera1.GetComponent<Camera>().depth = 0;

		camera1.GetComponent<MouseLook> ().sensitivityX = 10;//sensitivity change
		camera1.GetComponent<MouseLook> ().sensitivityY = 10;//sensitivity change
		GameObject.FindWithTag ("Player").GetComponent<MouseLook>().sensitivityX=15;//sensitivity change
    }
    void OnGUI()//draw current ammo
    {
        bulletGUI.text = "" + curAmmo + "/" + inventoryAmmo;

    }
}

	
	


				
	
	