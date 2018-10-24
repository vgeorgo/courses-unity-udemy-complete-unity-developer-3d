using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	int score = 0;
	Text txtScore;

	void Start ()
	{
		txtScore = GetComponent<Text>();
		UpdateWithScore();
	}

	void Update ()
	{
		
	}

	void UpdateWithScore()
	{
		txtScore.text = score.ToString();
	}

	public void ScoreHit(int scoreAdd = 0)
	{
		score += scoreAdd;
		UpdateWithScore();
	}
}
