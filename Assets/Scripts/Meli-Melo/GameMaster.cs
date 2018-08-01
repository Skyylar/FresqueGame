using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Transform emptyboxPrefab;
    public Transform letterBox;
    private string theWord = "imprimerie";
    private float posXEmpty = -4.5F;
    private float posXLetter = -4.5F;
    public int index;
    private string question = "Qu'inventa Gutemberg pour copier les livres ?";
    public Button onlyOne;

    private string answer;
    private List<char> letters;
    private List<int> stock;
    private List<int> emptyBoxInstancesId;
    private GameObject[] usable;
    private int nbTry;
    private int score;


    // Use this for initialization
    void Start () {
        letters = new List<char>();
        stock = new List<int>();
        emptyBoxInstancesId = new List<int>();
        index = 0;
        answer = "";

        GameObject emptyQuestion = GameObject.Find("Question");
        emptyQuestion.GetComponent<TextMesh>().text = question;

        for (int x = 0; x < theWord.Length; x++)
        {
            if (theWord[x] != ' ')
            {
                Transform boxClone = Instantiate(emptyboxPrefab, new Vector3(posXEmpty, 1, 0), Quaternion.identity);
                emptyBoxInstancesId.Add(boxClone.GetInstanceID());
                boxClone.name = boxClone.GetInstanceID().ToString();
                letters.Add(theWord[x]);
            }
            posXEmpty += 1F;
        }
        nbTry = 1;
        GenerateLetters();
    }

    private void GenerateLetters()
    {
        int random = 0;
        float tmp = posXLetter;
        for (int x = 0; x < theWord.Length; x++)
        {
            if (theWord[x] != ' ')
            {
                random = (int)Math.Round(UnityEngine.Random.Range(0F, (float)letters.Count - 1));
                while (CheckNumber(random))
                {
                    random = (int)Math.Round(UnityEngine.Random.Range(0F, (float)letters.Count - 1));
                }
                Transform boxClone2 = Instantiate(letterBox, new Vector3(posXLetter, -2, 0), Quaternion.identity);
                boxClone2.GetChild(0).GetComponent<TextMesh>().text = letters[random].ToString();
                boxClone2.tag = "Usable Letters";
                posXLetter += 1F;
            }
        }
        stock.Clear();
        posXLetter = tmp;
        Button quit = onlyOne.GetComponent<Button>();
        quit.onClick.AddListener(ResetLetters);
    }

    public void incIndex()
    {
        index++;
    }

    public List<int> GetInstancesList()
    {
        return emptyBoxInstancesId;
    }

    private static void PrintS(char s)
    {
        Debug.Log(s);
    }

    private bool CheckNumber(int number)
    {
        if (stock.Contains(number))
            return true;
        else
        {
            stock.Add(number);
            return false;
        }
    }

    public void addCharToAnswer(string s)
    {
        answer += s;
    }

	// Update is called once per frame
	void Update () {
        if (index == theWord.Replace(" ", "").Length)
        {
            if (answer == theWord.Replace(" ", ""))
            {
                GameManager.NoteMeliMelo = 20 - Mathf.RoundToInt(nbTry / 1.25F);
                GameManager.NumberNote += 1;
                Button quit = onlyOne.GetComponent<Button>();
                quit.GetComponentInChildren<Text>().text = "Quitter";
                quit.onClick.RemoveAllListeners();
                quit.onClick.AddListener(Exit);
            }
            else
            {
                ResetLetters();
            }
        }
    }

    void Exit()
    {
        Debug.Log(nbTry);
    }

    public void ResetLetters()
    {
        nbTry++;
        answer = "";
        index = 0;
        GameObject[] fillable;
        fillable = GameObject.FindGameObjectsWithTag("Fillable Box");
        for (int i = 0; i < fillable.Length; i++)
        {
            fillable[i].transform.GetChild(0).GetComponent<TextMesh>().text = " ";
        }
        GameObject[] usable;
        usable = GameObject.FindGameObjectsWithTag("Usable Letters");
        for (int i = 0; i < usable.Length; i++)
        {
            Destroy(usable[i]);
        }
        GenerateLetters();
    }
}
