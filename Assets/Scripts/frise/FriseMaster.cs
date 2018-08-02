using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class FriseMaster : MonoBehaviour {

    private bool disableFind = false;
    private bool disableQuizz = false;
    private bool disablePuzzle = false;
    private bool disableMeli = false;

    [DllImport("__Internal")]
    private static extern void SendScore(int score);
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        disableGames();
	}


    private void disableGames()
    {
        if (GameManager.NoteFindObject != 0 && !disableFind)
        {
            disableFind = true;
            disableClick("Prehistoire");
        }
        if (GameManager.NoteQuiz != 0 && !disableQuizz)
        {
            disableQuizz = true;
            disableClick("TempsModernes");
        }
        if (GameManager.NotePuzzle != 0 && !disablePuzzle)
        {
            disablePuzzle = true;
            disableClick("Antiquite");
        }
        if (GameManager.NoteMeliMelo != 0 && !disableMeli)
        {
            disableMeli = true;
            disableClick("MoyenAge");
        }
    }

    private void disableClick(string name)
    {
        GameObject.Find(name).GetComponent<BoxCollider>().enabled = false;
        GameObject.Find(name).GetComponent<ClickOnBox>().enabled = false;
    }


    public void sendScore()
    {
        int score = 0;
        if (GameManager.NumberNote != 0) 
        {
            score = (int)(GameManager.NoteFindObject + GameManager.NoteMeliMelo + GameManager.NotePuzzle + GameManager.NoteQuiz) / GameManager.NumberNote;   
        }
        Debug.Log(GameManager.NumberNote);
        Debug.Log(score);

        SendScore(score);
    }
}
