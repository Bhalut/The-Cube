using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour {

	public Transform[] target;
	private int pointTarget;
	[SerializeField]
	private float speed;
	public GameObject player;
	public GameObject canvas;
	public Transform platform;
	public Animator anim;
	public GameObject doors;

	void Awake () {
		anim = doors.GetComponent<Animator> ();
	}

	void Start(){
		canvas.SetActive(false);
	}

	IEnumerator Desplace() 
	{
		for (float i = 50f; i >= 0; i -= 0.1f) 
		{
			float step = speed * Time.deltaTime;
			Debug.Log (pointTarget);
			transform.position = Vector3.MoveTowards(transform.position, target[pointTarget].position, step);
			player.transform.SetParent(platform);
			if (transform.position == target[pointTarget].position) 
			{
				OnBotton ();
				break;
			}
			yield return null;
		}
		anim.SetBool ("IsActive", true); 
		Debug.Log ("hola");
		yield return new WaitForSeconds(3);
		anim.SetBool ("IsActive", false);
	}

	IEnumerator Door() 
	{
		anim.SetBool ("IsActive", true); 
		Debug.Log ("hola");
		yield return new WaitForSeconds(3);
		anim.SetBool ("IsActive", false);
	}
		
	public void CallBotton(string namePiso)
	{
		switch (namePiso)
		{
		case "uno":
			pointTarget = 0;
			StartCoroutine ("Desplace");
			Debug.Log ("Mover a piso 1");
			break;
		case "dos":
			pointTarget = 1;
			StartCoroutine ("Desplace");
			Debug.Log("Mover a piso 2");
			break;
		case "tres":
			pointTarget = 2;
			StartCoroutine ("Desplace");
			Debug.Log ("Mover a piso 3");
			break;
		case "cuatro":
			pointTarget = 3;
			StartCoroutine ("Desplace");
			Debug.Log("Mover a piso 4");
			break;
		case "cinco":
			pointTarget = 4;
			StartCoroutine ("Desplace");
			Debug.Log ("Mover a piso 5");
			break;
		case "seis":
			pointTarget = 5;
			StartCoroutine ("Desplace");
			Debug.Log("Mover a piso 6");
			break;
		case "siete":
			pointTarget = 6;
			StartCoroutine ("Desplace");
			Debug.Log ("Mover a piso 7");
			break;
		case "ocho":
			pointTarget = 7;
			StartCoroutine ("Desplace");
			Debug.Log("Mover a piso 8");
			break;
		case "nueve":
			pointTarget = 8;
			StartCoroutine ("Desplace");
			Debug.Log ("Mover a piso 9");
			break;
		case "diez":
			pointTarget = 9;
			StartCoroutine ("Desplace");
			Debug.Log("Mover a piso 10");
			break;
		case "close":
			anim.SetBool ("IsActive", false);
			Debug.Log ("Close");
			break;
		case "open":
			StartCoroutine ("Door");
			Debug.Log("Open");
			break;
		default:
			Debug.Log("El nombre es incorrecto");
			break;
		}	
	}

	public void OnBotton(){
		canvas.SetActive(true);
		Debug.Log ("OnBotton");
	}

	public void OnTriggerEnter(Collider other){
		if (other.CompareTag("parada")) {
			Debug.Log ("llego...");
		}
	}

	public void OnTriggerExit(){
		canvas.SetActive(false);
		Debug.Log ("salio...");
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.CompareTag("Player")){
			player.transform.SetParent(platform);
			Debug.Log("Tocando el player");
		}    
	}

	void OnCollisionExit(){
			player.transform.SetParent (null);
			Debug.Log ("No hace contacto");
	}
}
