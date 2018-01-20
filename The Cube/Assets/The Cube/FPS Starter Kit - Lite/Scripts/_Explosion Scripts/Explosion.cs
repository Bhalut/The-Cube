using UnityEngine;
using System.Collections;
 
public class Explosion : MonoBehaviour 
{
    public float Radius;// explosion radius
    public float Force;// explosion forse
    void Update () 
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);// create explosion
        for(int i=0; i<hitColliders.Length; i++)
        {              
			if(hitColliders[i].GetComponent<Robot_Destroy>())// if hit robot
            {
				hitColliders[i].GetComponent<Robot_Destroy>().Robot_health-=hitColliders[i].GetComponent<Robot_Destroy>().explosion_damage;// robot health - explosion damage
			}
            if(hitColliders[i].CompareTag("CanBeRigidbody"))// if tag CanBeRigidbody
            {
                if(!hitColliders[i].GetComponent<Rigidbody>())
                {
                hitColliders[i].gameObject.AddComponent<Rigidbody>();
                }
                hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(Force, transform.position, Radius, 0.0F); // push game object
            }
			 if(hitColliders[i].GetComponent<Health>())// if hit fpc
            {
			 hitColliders[i].GetComponent<Health>().Del(); // player health - explosion damage 	
            }
			
        }
        Destroy(gameObject,0.2f);// destroy explosion
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
}