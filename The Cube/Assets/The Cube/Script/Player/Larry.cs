using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Larry : MonoBehaviour
{
	private int forceConst = 5;
	private float speed = 10.0F;
	private float rotationSpeed = 100.0F;
	private bool walking;
	private bool death;
	private Animator anim;

	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public static int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.

	bool isDead;                                                // Whether the player is dead.

	void Awake ()
	{
		anim = GetComponent<Animator> ();
	}

	void Start()
	{
		death = true;

			// Set the initial health of the player.
			currentHealth = startingHealth;

			healthSlider.value = currentHealth;

	}

	void Update ()
	{
		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;

		if (Time.timeScale == 1 && death == true)
		{
			float translation = Input.GetAxis ("Vertical") * speed;
			translation *= Time.deltaTime;
			transform.Translate (0, 0, translation);

			float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
			rotation *= Time.deltaTime;
			transform.Rotate (0, rotation, 0);

			_Animation (rotation,translation);
		}
	}

	void _Animation (float h, float v)
	{
		walking = h != 0f || v != 0f;
		//anim.SetBool ("IsWalking", walking);
	}

	public void TakeDamagePlayer (int amount)
	{
			// Reduce the current health by the damage amount.
			currentHealth -= amount;

			Debug.Log(currentHealth);

			// If the player has lost all it's health and the death flag hasn't been set yet...
			if(currentHealth <= 0 && !isDead)
			{
					// ... it should die.
					Death ();
			}
	}

	void Death ()
	{
			// Set the death flag so this function won't be called again.
			isDead = true;

			// Tell the animator that the player is dead.
			//anim.SetTrigger ("Die");
	}
}
