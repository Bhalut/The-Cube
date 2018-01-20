using UnityEngine;
using System.Collections;

public class Robot_Move : MonoBehaviour
{

    private Animator anim;// robot animator
    private Transform target;// robot target
    private UnityEngine.AI.NavMeshAgent agent;// robot navmeshagent
    private GameObject _player;
    private Transform _target;

	public bool CanShoot;
	public float stop_distance;
	public float shoot_distance;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();// get animator
        GameObject go = GameObject.FindGameObjectWithTag("Player");// find player
        target = go.transform;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();// get navmeshagent
        _player = GameObject.FindGameObjectWithTag("Player");// find player
        _target = _player.transform;

    }

    void Update()
    {
		agent.stoppingDistance = stop_distance;
        agent.SetDestination(_target.position);

		if (Vector3.Distance(transform.position, target.position) > stop_distance)// if distance(robot-fps) >10
        {

            anim.SetBool("CanWalk", true);// play animation in animator
        }
        else
        {

            anim.SetBool("CanWalk", false);// play animation in animator
        }

		if (Vector3.Distance(transform.position, target.position) > shoot_distance)// if distance(robot-fps) > 20
        {

            CanShoot = false;// not shoot
        }
        else
        {
            CanShoot = true;// shoot
        }
    }
}


