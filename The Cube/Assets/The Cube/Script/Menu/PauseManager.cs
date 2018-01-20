using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
	private Canvas canvas;

	void Start ()
	{
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 0)
			{
				Continue();
			}
			else if (Time.timeScale == 1)
			{
				Pause();
			}
		}
	}

	public void Pause()
	{
		canvas.enabled = true;
		Time.timeScale = 0;
	}

	public void Continue()
	{
		StartCoroutine(CountDown());
	}

	public void Tutorial()
	{
		SceneManager.LoadScene ("Tutorial");
	}

	public void Quit()
	{
		SceneManager.LoadScene ("Main");
	}

	IEnumerator CountDown()
	{
		canvas.enabled = false;
		yield return new WaitForSecondsRealtime(3);
		Time.timeScale = 1;
	}
}
