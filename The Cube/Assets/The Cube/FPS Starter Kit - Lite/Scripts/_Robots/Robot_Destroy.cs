using UnityEngine;
using System.Collections;

public class Robot_Destroy : MonoBehaviour
{
	public int gun_damage;
	public int machine_damage;
	public int submachinegun_damage;
	public int sniperrifle_damage;
	public int explosion_damage;
	public int firedamage;
	public int knifedamage;
    public float Robot_health = 100;// robot health
    public Transform ragdoll; // robot ragdoll
	public TextMesh robot_health;
    int a = 0;


    void Update()
    {
		robot_health.text = "" + Robot_health;
			if (Robot_health <= 0)
        {
            Destroy(gameObject);// destroy robot
            if (ragdoll)
            {
                Transform dead = Instantiate(ragdoll, transform.position, transform.rotation) as Transform;// create ragdoll
                CopyTransformsRecurse(transform, dead);                                                    //
            }
            a = PlayerPrefs.GetInt("Score"); //
            a++;                             // score calculation 
            PlayerPrefs.SetInt("Score", a);  //
        }
    }


    static void CopyTransformsRecurse(Transform src, Transform dst)// ragdoll position
    {
        dst.position = src.position;
        dst.rotation = src.rotation;

        foreach (Transform child in dst)
        {
            var curSrc = src.Find(child.name);
            if (curSrc)
                CopyTransformsRecurse(curSrc, child);
        }
    }
    void OnTriggerStay(Collider Col)
    {
        if (Col.tag == "Fire")
        {// if robot in fire 
			Robot_health -= firedamage;
        }
    }
    void OnTriggerEnter(Collider Col2)
    {
        if (Col2.tag == "Knife")
        { // if hit knife 
			Robot_health -= knifedamage;
        }
    }
}

