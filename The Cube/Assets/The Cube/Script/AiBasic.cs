using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBasic : MonoBehaviour {

	public Transform player;
	public List<GameObject> DestinationPoints;

	public float speed;
	public float alertDistance;
	public float walkingDistance;
	public float attackingDistance;
	public float remainigDistance;
	public int minTime;
	public int maxTime;

	private Vector3 direction;
	private Animator anim;
	private NavMeshAgent agent;
	private int selectedDestination;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		agent.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		if (agent.enabled == true && agent.remainingDistance < remainigDistance) {
			agent.enabled = false;
			anim.SetBool ("IsIdle", true);
			anim.SetBool ("IsAlert", false);
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsWalking", false);

			StartCoroutine (RandomMovement());
			Debug.Log ("Arrived...");
		}

		//Alert
		if (Vector3.Distance(player.position, transform.position) < alertDistance &&
			Vector3.Distance(player.position, transform.position) > attackingDistance )
			{
			agent.enabled = false;

			anim.SetBool ("IsAlert", true);
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsWalking", false);
			anim.SetBool ("IsIdle", false);
		}

		//Moving and Attacking
		else if (Vector3.Distance(player.position, transform.position) < walkingDistance)
		{
			agent.enabled = true;

			/*direction = player.position - transform.position;
			direction.y = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.9f * Time.deltaTime);
			transform.Translate (0, 0, speed);*/

			agent.SetDestination (player.transform.position);

			anim.SetBool ("IsWalking", true);
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsAlert", false);
			anim.SetBool ("IsIdle", false);

			if (direction.magnitude <= attackingDistance) {
				anim.SetBool ("IsAttacking", true);
				anim.SetBool ("IsWalking", false);
				anim.SetBool ("IsAlert", false);
				anim.SetBool ("IsIdle", false);
			}
		}

		//Idle
		else if (anim.GetBool("IsIdle") == false && agent.enabled == false) {
			anim.SetBool ("IsIdle", true);
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsAlert", false);
			anim.SetBool ("IsWalking", false);
			StartCoroutine(RandomMovement());
		}
	}

	public IEnumerator RandomMovement()
	{
		int index = Random.Range (minTime, maxTime);
		Debug.Log ("RandomTime " + index);
		yield return new WaitForSeconds (index);

		int index2 = Random.Range (1, 3);
		switch (index2)
		{
		case 1:
			//keeps being Idle and calls RandomMovement again
			Debug.Log("KeepIdle...");
			StartCoroutine(RandomMovement());
			break;
		case 2:
			//picks a random destination, and move
			Debug.Log ("Move...");
			agent.enabled = true;
			int lastDestination = selectedDestination;
			selectedDestination = Random.Range (0, DestinationPoints.Count);

			while (selectedDestination == lastDestination || DestinationPoints [selectedDestination].GetComponent<DestinationPointScript> ().isUsed == true)
			{
				selectedDestination = Random.Range (0, DestinationPoints.Count);
			}

			DestinationPoints [lastDestination].GetComponent<DestinationPointScript> ().isUsed = false;
			agent.SetDestination (DestinationPoints [selectedDestination].transform.position);
			DestinationPoints [selectedDestination].GetComponent<DestinationPointScript> ().isUsed = true;

			anim.SetBool ("IsWalking", true);
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsAttacking", false);
			anim.SetBool ("IsAlert", false);
			break;
		default:
			Debug.Log ("Invalid");
			break;
		}

	}
}
