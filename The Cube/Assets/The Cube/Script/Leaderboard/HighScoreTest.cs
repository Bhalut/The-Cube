using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScoreTest : MonoBehaviour {

	string name = "";
	string score = "";
	List<Scores> highscore;
	
	void Start () {		
		highscore = new List<Scores>();		
	}
	
	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Label("Name :");
		name =  GUILayout.TextField(name);
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Score :");
		score =  GUILayout.TextField(score);
		GUILayout.EndHorizontal();
		
		if(GUILayout.Button("Add Score"))
		{
			HighScoreManager._instance.SaveHighScore(name,System.Int32.Parse(score));
			highscore = HighScoreManager._instance.GetHighScore();	
		}
		
		if(GUILayout.Button("Get LeaderBoard"))
		{
			highscore = HighScoreManager._instance.GetHighScore();			
		}
		
		if(GUILayout.Button("Clear Leaderboard"))
		{
			HighScoreManager._instance.ClearLeaderBoard();			
		}
		
		GUILayout.Space(60);
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Name",GUILayout.Width(Screen.width/2));
		GUILayout.Label("Scores",GUILayout.Width(Screen.width/2));
		GUILayout.EndHorizontal();
		
		GUILayout.Space(25);
		
		foreach(Scores _score in highscore)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(_score.name,GUILayout.Width(Screen.width/2));
			GUILayout.Label(""+_score.score,GUILayout.Width(Screen.width/2));
			GUILayout.EndHorizontal();
		}
	}
}
