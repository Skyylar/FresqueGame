using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "Score :" + TextControl.totalCorrect + "/" + TextControl.totalQuestions;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
