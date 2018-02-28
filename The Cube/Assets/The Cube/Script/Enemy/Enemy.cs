using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public int startingHealth = 100;          // The amount of health the enemy starts the game with.
	public int currentHealth;                    // The current health the enemy has.
	public float sinkSpeed = 2.5f;           // The speed at which the enemy sinks through the floor when dead.
	public int scoreValue = 10;               // The amount added to the player's score when the enemy dies.

	bool isDead;                                  // Whether the enemy is dead.
	bool isSinking;                               // Whether the enemy has started sinking through the floor.

	float timer;                                // Timer for counting up to the next attack.

	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.

	private bool isDeath;
	private bool playerInRange;									// Whether player is within the trigger collider and can be attacked.
	private float timerAttack = 2f;
	GameObject player;                          // Reference to the player GameObject.
	private Larry ly;
	private NavMeshAgent nav;
	private int _health;
	private float hit;

	void Awake(){
		nav = GetComponent<NavMeshAgent> ();
		ly = GetComponent<Larry>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {
		GameObject playerTemp = GameObject.Find ("Player");
		if (playerTemp != null) {
			ly = playerTemp.GetComponent<Larry> ();
		}
		nav.enabled = true;

		// Setting the current health when the enemy first spawns.
		currentHealth = startingHealth;
	}

	void Update ()
	{
		if (isDeath == false && nav.enabled == true)
		{
			 nav.SetDestination (player.transform.position);
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;

			// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
			if(timer >= timeBetweenAttacks && playerInRange && currentHealth > 0 )
			{
					// ... attack.
					Attack ();
			}
		}
	}

	void Attack ()
	{
		Larry _player = new Larry();
			// Reset the timer.
			timer = 0f;

			// If the player has health to lose...
			if(Larry.currentHealth > 0)
			{
					// ... damage the player.
					_player.TakeDamagePlayer(attackDamage);

					Debug.Log(attackDamage);
			}
	}

	public void TakeDamage (int amount)
	{
			// If the enemy is dead...
			if(isDead)
			{
				// ... no need to take damage so exit the function.
				return;
			}

			// Reduce the current health by the amount of damage sustained.
			currentHealth -= amount;

			Debug.Log(currentHealth);
			// If the current health is less than or equal to zero...
			if(currentHealth <= 0)
			{
					// ... the enemy is dead.
					Death ();
			}
	}

	void Death ()
	{

			// The enemy is dead.
			isDead = true;

			Destroy (gameObject);
			// Tell the animator that the enemy is dead.
			//anim.SetTrigger ("Dead");
	}

	public void StartSinking ()
	{
			// Find and disable the Nav Mesh Agent.
			nav.enabled = false;

			// Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
			GetComponent <Rigidbody> ().isKinematic = true;

			// The enemy should no sink.
			isSinking = true;

			// Increase the score by the enemy's score value.
			ScoreManager.score += scoreValue;

			// After 2 seconds destory the enemy.
			Destroy (gameObject, 2f);
	}

	void OnCollisionStay(Collision collision){
		if (collision.gameObject.CompareTag("Player"))
		{
			playerInRange = true;
		}
	}

	void OnCollisionExit(Collision collision){
		if (collision.gameObject.CompareTag("Player"))
		{
			playerInRange = false;
		}
	}
}
