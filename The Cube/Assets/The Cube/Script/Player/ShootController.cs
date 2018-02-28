using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public int dange = 45;
	public float timeBullet = 0.15f;
	public float range = 100f;

	private int shootableMask;
	private float timer;
	private float effectGun = 0.2f;
	private Ray shootRay;
	private RaycastHit shootHit;

	private LineRenderer gunLine;
	private Light gunLight;

	void Awake()
	{
		gunLine = GetComponent<LineRenderer> ();
		gunLight = GetComponent<Light> ();
	}

	void Start ()
	{
		shootableMask = LayerMask.GetMask ("Shooteable");
	}

	void Update () 
    {
		if (Time.timeScale == 1)
		{
			timer += Time.deltaTime;

			if (Input.GetButton("Fire1") && timer >= timeBullet )
			{
				Shoot ();
			}
			if (timer >= timeBullet * effectGun)
			{
				DisableEffects ();
			}
		}
	}

	public void DisableEffects()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot()
	{
		timer = 0f;
		gunLight.enabled = true;
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{
			Enemy enemy = shootHit.collider.GetComponent<Enemy> ();
			if (enemy != null)
			{
				enemy.TakeDamage (dange);
			}
			gunLine.SetPosition (1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay (shootRay);
	}
}
