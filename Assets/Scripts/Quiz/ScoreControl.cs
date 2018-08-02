using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour {


	void Start () {
        // Affiche le score en fonction du nombre de question dans la liste
        GetComponent<TextMesh>().text = "Score :" + TextControl.totalCorrect + "/" + TextControl.totalQuestions;
        GameManager.NoteQuiz = (int)(TextControl.totalCorrect * 4);
        GameManager.NumberNote += 1;
	}

	void Update () {
		
	}
}
