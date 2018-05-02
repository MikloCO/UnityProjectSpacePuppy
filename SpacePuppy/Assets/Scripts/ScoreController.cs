using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO; 

public class ScoreController : MonoBehaviour {
	
	private float[] allHighScore;
	private GameObject playerProgress;

	private string gameDataFileName = "data.json";

	void Start()
	{
		
	}

	public float getHighScore()
	{
		return allHighScore[];
	}

}
