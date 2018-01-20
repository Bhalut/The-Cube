using UnityEngine;
using System.Collections;
 
public class Rocket : MonoBehaviour 
{
    public bool Activate;
    public float Speed;// rocket speed
    private float timeout;
    private float lifetimeout;
    private int _scatter;
    public int Scatter;
    public Transform physicExplosion; 
    public Transform graphicExplosion;
    public Transform Smoke;// rocket smoke
    public Transform Fire;// rocket fire

    void Start () {
        Smoke.GetComponent<ParticleEmitter>().emit = false;// deactivation fire an smoke
        Fire.GetComponent<ParticleEmitter>().emit = false; //
    }
     

    void Update () 
    {
        if(Activate==true)
        {
            if(Smoke.GetComponent<ParticleEmitter>().emit==false)
            {
                Smoke.GetComponent<ParticleEmitter>().emit = true;// activation smoke
            }
            if(Fire.GetComponent<ParticleEmitter>().emit==false)
            {
                Fire.GetComponent<ParticleEmitter>().emit = true;// activation fire
            }
            timeout+=Time.deltaTime;
            lifetimeout+=Time.deltaTime;
            if(timeout>2)
            {
                _scatter = Random.Range(-Scatter,Scatter);
                timeout = 0;
            }
            transform.Translate(Vector3.forward*Speed*Time.deltaTime);// transform rocket
            transform.RotateAround(transform.position, transform.TransformDirection(Vector3.right), _scatter*Time.deltaTime);// rotate rocket
            transform.RotateAround(transform.position, transform.TransformDirection(Vector3.up), _scatter*Time.deltaTime);// rotate rocket
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),1.4f))
            {
                Dead();// delete rocket
            }
            if(lifetimeout>10)
            {
                Dead();
            }
        }
    }
    public void Dead()
    {
        Instantiate(physicExplosion,transform.position+transform.TransformDirection(Vector3.forward)*1.4f,transform.rotation);// create physics explosion
        Instantiate(graphicExplosion,transform.position+transform.TransformDirection(Vector3.forward)*1.4f,transform.rotation);// create graphic explosion
        Smoke.GetComponent<ParticleEmitter>().emit = false;// deactivation smoke
        Smoke.parent = null;
        Destroy(Smoke.gameObject,7);// delete smoke (after 7 second)
        Destroy(gameObject);// delete rocket
    }
     
}


