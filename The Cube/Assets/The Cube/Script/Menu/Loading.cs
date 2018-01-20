using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

	public GameObject imageCharge;
	public Slider load;

	public void ClickCharge (string level)
	{
		imageCharge.SetActive (true);
		StartCoroutine(levelsceneslider(level));
	}

	IEnumerator levelsceneslider(string level)
	{
		AsyncOperation asyn = SceneManager.LoadSceneAsync (level);
		while (!asyn.isDone)
		{
			load.value = asyn.progress;
			yield return null;
			Debug.Log ("Level Complete");
		}
	}
}
