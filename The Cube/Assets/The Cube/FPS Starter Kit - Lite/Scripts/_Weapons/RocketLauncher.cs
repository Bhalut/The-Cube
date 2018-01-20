using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour
{
    public Transform _RocketLauncher;//rocket launcher
    public Transform RocketRespawn;//rocket spawn point
    public Transform rocket;//rocket prefab
    public int rpgmode;//animation mode
    private float rpgreload1;
    public AudioClip Reloaded;//audio
    public AudioClip Shoot;   //
    public bool CanShoot;
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;
    public int curAmmo = 12;// current ammo
    public int maxAmmo = 12;//max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    public GUIText bulletGUI; // text which shows the current ammo

    public AnimationClip _Idle;  //
    public AnimationClip _Reload;// animations
    public AnimationClip _Shoot; //
    string _idle_;
    string _reload_;
    string _shoot_;
    public Transform camera1;// fpc camera

    void Start()
    {
        Transform go = Instantiate(rocket, RocketRespawn.position, RocketRespawn.rotation) as Transform;
		go.parent = _RocketLauncher;// create rocket
    }
    void Update()
    {

        _idle_ = _Idle.name;    //  get name of animation
        _reload_ = _Reload.name;//
        _shoot_ = _Shoot.name;  //


        if (_rateofSpeed <= RateOfSpeed)//rate of shoot
        {
            _rateofSpeed += Time.deltaTime;
        }

        if (rpgmode == 0)
        {

            GetComponent<Animation>().CrossFade(_idle_);// idle animations
        }
        
		if (Input.GetButtonDown("Attack") & curAmmo > 0 & _rateofSpeed > RateOfSpeed & rpgmode == 0)//if shoot
        {
            Shot();
        }

		if (Input.GetButtonDown("Reload") & rpgmode < 4 & inventoryAmmo > 0 & curAmmo != maxAmmo)// if reload
        {
            GetComponent<AudioSource>().PlayOneShot(Reloaded);// play audio
            rpgmode = 4;//animation mode
            GetComponent<Animation>().CrossFade(_reload_);// reload animation
        }
        if (rpgmode == 4)
        {
            rpgreload1 += Time.deltaTime;

        }
        if (rpgreload1 > GetComponent<Animation>()[_reload_].length)
        {
            rpgreload1 = 0;
            rpgmode = 0;// animation mode
            Transform go = Instantiate(rocket, RocketRespawn.position, RocketRespawn.rotation) as Transform;
			go.parent = _RocketLauncher;// create rocket
            Reload();
        }

    }
    public void Reload_()
    {
        if (curAmmo > 0)
        {
            Transform go = Instantiate(rocket, RocketRespawn.position, RocketRespawn.rotation) as Transform;
            go.parent = _RocketLauncher;// create rocket
        }

    }

    public void Shot()
    {
        GetComponent<AudioSource>().PlayOneShot(Shoot);// play audio
        GetComponent<Animation>().Play(_shoot_);// shoot animation
        Transform rocket = transform.Find("rocket(Clone)");// find rocket
        rocket.GetComponent<Rocket>().Activate = true;// activation rocket
        rocket.parent = null;
        curAmmo -= 1;// ammo consumption
        Reload_();
        _rateofSpeed = 0;

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
    void OnGUI()//draw current ammo
    {
        bulletGUI.text = "" + curAmmo + "/" + inventoryAmmo;
    }
}
