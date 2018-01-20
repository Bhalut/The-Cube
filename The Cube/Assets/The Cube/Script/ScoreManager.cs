using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static int score;        // The player's score.
	Text text;                      // Reference to the Text component.

	void Awake ()
	{
			// Set up the reference.
			text = GetComponent <Text> ();
	}

	void Start()
	{
		// Reset the score.
		score = 0;
	}

	void Update ()
	{
			// Set the displayed text to be the word "Score" followed by the score value.
			text.text = "SCORE: " + score;
	}
}
