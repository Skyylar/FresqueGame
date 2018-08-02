using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class FriseMaster : MonoBehaviour {

    private bool disableFind = false;
    private bool disableQuizz = false;
    private bool disablePuzzle = false;
    private bool disableMeli = false;
    public GameObject ExitButton;
    private int score = 0;

    [DllImport("__Internal")]
    private static extern void SendScore(int score);


    // Use this for initialization
    void Start()
    {
        //GameObject.Find("ButtonExit").GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update () {
        disableGames();
        setNote();
        if (GameManager.NumberNote == 4)
        {
            SendScore(score);
            ExitButton.SetActive(true);
        }
	}

    private void setNote()
    {
        if (GameManager.NumberNote > 0)
        {
            score = (int)(GameManager.NoteFindObject + GameManager.NoteMeliMelo + GameManager.NotePuzzle + GameManager.NoteQuiz) / GameManager.NumberNote;
            GameObject.Find("NoteObject").GetComponent<TextMesh>().text = score.ToString() + "/20";
        } else
        {
            GameObject.Find("NoteObject").GetComponent<TextMesh>().text = "";
        }
    }

    private void disableGames()
    {
        if (GameManager.NoteFindObject != 0 && !disableFind)
        {
            disableFind = true;
            disableClick("Prehistoire");
            enableStar(1);
        }
        if (GameManager.NoteQuiz != 0 && !disableQuizz)
        {
            disableQuizz = true;
            disableClick("TempsModernes");
            enableStar(4);
        }
        if (GameManager.NotePuzzle != 0 && !disablePuzzle)
        {
            disablePuzzle = true;
            disableClick("Antiquite");
            enableStar(2);
        }
        if (GameManager.NoteMeliMelo != 0 && !disableMeli)
        {
            disableMeli = true;
            disableClick("MoyenAge");
            enableStar(3);
        }
    }

    private void disableClick(string name)
    {
        GameObject.Find(name).GetComponent<BoxCollider>().enabled = false;
        GameObject.Find(name).GetComponent<ClickOnBox>().enabled = false;
    }

    private void enableStar(int i)
    {
        GameObject star = GameObject.Find("star" + i.ToString());
        Color tmp = star.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        star.GetComponent<SpriteRenderer>().color = tmp;
    }


    public void sendScore() => SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
}
