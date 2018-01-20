using UnityEngine;
using System.Collections;

public class ActivateAudio : MonoBehaviour {

	public AudioSource audioM;

	void Start()
	{
		audioM = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioM.Play();
            Debug.Log("Audio Activado");
        }
    }
}
