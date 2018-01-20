using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ArenaControl : MonoBehaviour
{
    public GameObject robot1;// the first wave of robots
	public GameObject robot2;// the second wave of robots

	void Start(){

		if (PlayerPrefs.GetInt("Score") == 0)// if score=0 
		{
			robot1.SetActive(true); // activate w1(the first wave of robots)
		}

		if (PlayerPrefs.GetInt("Score") == 1)//if score=1 
		{

			robot1.SetActive(false);//  deactivate w1(the first wave of robots)
			robot2.SetActive(true);//   activate w2(the second wave of robots)
		}
	}

    void Update()
    {

		if (Input.GetKeyDown(KeyCode.Q))// if reset progress then score =0;
        {
            
			SceneManager.LoadScene (0, LoadSceneMode.Single);//reload scene
			PlayerPrefs.SetInt("Score", 0);

        }

        if (PlayerPrefs.GetInt("Score") == 0)// if score=0 
        {
			robot1.SetActive(true); // activate w1(the first wave of robots)
        }

        if (PlayerPrefs.GetInt("Score") == 1)//if score=1 
        {
			
			robot2.SetActive(true);//   activate w2(the second wave of robots)
        }
    }
}

