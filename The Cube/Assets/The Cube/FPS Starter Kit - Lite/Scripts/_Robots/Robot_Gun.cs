using UnityEngine;
using System.Collections;

public class Robot_Gun : MonoBehaviour {

	private RaycastHit Hit;// raycast ray
    public float Accuracy = 0.01f;//accuracy of bullets
    public Health sd;//links to fpc scripts (health)
    public Transform spawn;// bullets spawn point
	public float RateOfSpeed=0.5f;// rate of shoot
    private float _rateofSpeed;
	private bool Shoot;
    public Transform [] _MuzzleFlash;// fire shoot
    public Light[] _Light;// light when shoot
	private float timeout = 0.2f;// timer
	public Robot_Move robot_move;//links to robot script (walk)

    void Update()
    {



        if (_rateofSpeed <= RateOfSpeed)//rate of shoot
        {
            _rateofSpeed += Time.deltaTime;
        }



        if (timeout < 0.1f) //light timer
        {
            timeout += Time.deltaTime;
            for (int i = 0; i < _Light.Length; i++)
            {
                _Light[i].range = 5;
            }
        }
        else
        {
            for (int i = 0; i < _Light.Length; i++)
            {
                _Light[i].range = 0;
            }
        }




        if (robot_move.CanShoot == true & _rateofSpeed > RateOfSpeed)// shoot
        {
            Vector3 Direction = spawn.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));//accuracy of bullet	
            timeout = 0;

            for (int i = 0; i < _MuzzleFlash.Length; i++)
            {

                _MuzzleFlash[i].GetComponent<ParticleEmitter>().emit = true;
            }
            _rateofSpeed = 0;
            if (Physics.Raycast(spawn.position, Direction, out Hit, 10000f))// create raycast ray
            {
                if (Hit.collider.CompareTag("Player"))//If ray hit player
                {
					Hit.collider.GetComponent<Health> ().player_health -= Hit.collider.GetComponent<Health> ().bullet_damage;// player health - 5
                }

                if (Hit.transform.GetComponent<Rigidbody>())// if ray hit rigidbody object
                {
                    Hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 500, Hit.point);// object push
                }          
            }
        }

        else
        {
            for (int i = 0; i < _MuzzleFlash.Length; i++)
            {

                _MuzzleFlash[i].GetComponent<ParticleEmitter>().emit = false;
            }
        }
    }
		
}



