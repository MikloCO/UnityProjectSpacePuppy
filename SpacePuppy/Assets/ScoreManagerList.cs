using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerList : MonoBehaviour {


	myText=GameObject.Find("MainText").GetComponent<Text>(); 

	Text text = highScoreArrays;

	public highScoreArray[] highScoreArrays;

	void Update() {
		
	}

	void StoreScoreInArray() {
		text = GetComponent <Text> ();
	}
}
