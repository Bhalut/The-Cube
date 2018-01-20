using UnityEngine;
using System.Collections;


	

public class WeaponManager : MonoBehaviour
{
	public int current_Weapon;// current weapon
	public bool can_change_weapons;

    public GameObject weapon1;//weapon 1 prefab
	public GameObject weapon2;//weapon 2 prefab
	public GameObject weapon3;//weapon 3 prefab

	public RocketLauncher rocket_launcher;	//
    public Gun gun;    						//
    public SnaiperRifle snaiper_rifle;		// links to weapons scripts

    private int weapon1_mode;
    private int weapon2_mode;
    private int weapon3_mode;


    public GameObject hptexture;  //
    public GameObject pattexture; //
    public GameObject grentexture;// ammo,health textures
    public GameObject hptext;     //
    public GameObject pattext;    //
    public GameObject grentext;   //


    void Start()
    {
		
		Null_Weapons();
		Null_Weapons_mode ();
        pattexture.SetActive(true);  //
        grentexture.SetActive(true); // 
        hptexture.SetActive(true);   //
        hptext.SetActive(true);      // activate all textures
        pattext.SetActive(true);     //
        grentext.SetActive(true);    //

    }

    void Update()
    {

		if (snaiper_rifle.aim == false & gun.aim == false) // if aim off
		{
			can_change_weapons = true;
		} 
		else 
		{
			can_change_weapons = false;
		}


		if ((Input.GetAxis ("Mouse ScrollWheel")< 0)  & can_change_weapons==true)// if sroll mouse button (up) and aim off(all weapons)
        {
			current_Weapon -= 1;
			Switch(); // switch weapon
        }
		if ((Input.GetAxis ("Mouse ScrollWheel") > 0) & can_change_weapons==true)// if sroll mouse button (down)and aim off(all weapons)
        {
			current_Weapon += 1;
			Switch(); // switch weapon
        }
		if (current_Weapon > 3)
        {
			current_Weapon = 1;
			Switch(); // switch weapon
        }
		if (current_Weapon < 1)
        {
			current_Weapon = 3;
			Switch(); // switch weapon
        }
		if (Input.GetKeyDown("1") & can_change_weapons==true)// if press "1",and aim off(all weapons)
        {
            if (weapon1_mode == 0)// if gun inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon1_mode = 1;      
				current_Weapon = 1; 
				Switch(); // switch weapon
            }
        }
		if (Input.GetKeyDown("2") & can_change_weapons==true)//if press "2",and aim off(all weapons)
        {
			if (weapon2_mode == 0)// if gun inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon2_mode = 1;   
				current_Weapon = 2;
				Switch(); // switch weapon 
            }
        }
		if (Input.GetKeyDown("3") & can_change_weapons==true)//if press "3",and aim off(all weapons)
        {
			if (weapon3_mode == 0)// if rocket launcher inactive
            {

				Null_Weapons_mode ();// deactivate all weapons
				weapon3_mode = 1;   
				current_Weapon = 3;
				Switch(); // switch weapon

            }
        }
		if (Input.GetKeyDown("0") & can_change_weapons==true)//if press "0",and aim off(all weapons)
        {
			Null_Weapons();
			Null_Weapons_mode ();
        }

    }

	public void Null_Weapons_mode(){
		
		weapon1_mode = 0;//
		weapon2_mode = 0;//deactivate all weapons mode
		weapon3_mode = 0;//
	}


   public void Null_Weapons()
    {
		weapon1.SetActive(false);//
		weapon2.SetActive(false);//deactivate all weapons 
		weapon3.SetActive(false);//
    }
   public void Switch()// switch weapons
    {

		if (current_Weapon == 1) {
			
				Null_Weapons ();
				weapon1.SetActive (true);//activate 1 weapon
				weapon1.GetComponent<Animation>().Play("Gun_On");			
		}
			
		if (current_Weapon == 2) {
				Null_Weapons ();
				weapon2.SetActive (true);//activate 2 weapon
				weapon2.GetComponent<Animation>().Play("SniperRifle_On");
		}

		if (current_Weapon == 3) {
				Null_Weapons ();
				weapon3.SetActive (true);//activate 3 weapon
				weapon3.GetComponent<Animation>().Play("RocketLauncher_On");
		}
    }
}


