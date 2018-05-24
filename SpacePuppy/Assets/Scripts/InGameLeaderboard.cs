using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class InGameLeaderboard : MonoBehaviour {
	
	private Text text;

	void Start(){
		text = GetComponentInChildren<Text> ();
		for (int i = 1; i <= 9; i++) {
			text.text += (i + " " + ":  " + PlayerPrefs.GetInt("highscore"+i) + "\n");
		}
		text.text += ("10 " + ":  " + PlayerPrefs.GetInt("highscore10"));
	}
}
