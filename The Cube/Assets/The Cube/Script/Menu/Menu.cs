using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject playMenuHolder;
	public GameObject quitMenuHolder;
	public GameObject creditMenuHolder;
	public GameObject settingMenuHolder;
	public Slider volumenSlider;
	public Toggle activeToggle;
	public AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource>();
	}

	public void Play (){
		playMenuHolder.SetActive (true);
		mainMenuHolder.SetActive (false);
		quitMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditMenuHolder.SetActive (false);
	} 

	public void PlayNew (){
		SceneManager.LoadScene ("Level One");
	} 

	public void Continue (){
		//Continue
	} 

	public void ExitPanel (){
		quitMenuHolder.SetActive (true);
		playMenuHolder.SetActive (false);
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditMenuHolder.SetActive (false);
	}

	public void Exit (){
		Application.Quit();
	}

	public void OptionsMenu (){
		optionsMenuHolder.SetActive (true);
		settingMenuHolder.SetActive (true);
		mainMenuHolder.SetActive (false);
		quitMenuHolder.SetActive (false);
		playMenuHolder.SetActive (false);
		creditMenuHolder.SetActive (false);
	}

	public void MainMenu(){
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
		quitMenuHolder.SetActive (false);
		playMenuHolder.SetActive (false);
		creditMenuHolder.SetActive (false);
	}

	public void Credit(){
		creditMenuHolder.SetActive (true);
		settingMenuHolder.SetActive (false);
		mainMenuHolder.SetActive (false);
		quitMenuHolder.SetActive (false);
		playMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}

	public void MusicMenu (){
		//AudioManager.intance.SetVolume(value, AudioManager.AudioChannel.Master);
		audio.volume = volumenSlider.value;
	}

	public void SFXMenu (){
		//AudioManager.intance.SetVolume(value, AudioManager.AudioChannel.Sfx);
		audio.volume = volumenSlider.value;
	}

	public void Mute (){
		audio.mute = !audio.mute;
	}
}
