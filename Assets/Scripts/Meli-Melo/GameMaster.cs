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
    private bool gameEnd = false;

    // Use this for initialization
    void Start () {
        //Initialize variables
        letters = new List<char>();
        stock = new List<int>();
        emptyBoxInstancesId = new List<int>();
        index = 0;
        answer = "";

        // Fill question space
        GameObject emptyQuestion = GameObject.Find("Question");
        emptyQuestion.GetComponent<TextMesh>().text = question;

        // Ganerate empty boxes with the word length
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

        //Set number of tries
        nbTry = 0;

        // generate letters of the word
        GenerateLetters();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the game ended and if the number of letters clicked is the same as the word
        if (!gameEnd && index == theWord.Replace(" ", "").Length)
        {
            //Check both value of the answer and the word
            if (answer == theWord.Replace(" ", ""))
            {
                gameEnd = true;

                //generate a mark
                GameManager.NoteMeliMelo = 20 - Mathf.RoundToInt(nbTry / 1.25F);
                GameManager.NumberNote += 1;

                //Remvove the retry button
                Destroy(onlyOne.gameObject);
            }
            else
            {
                //regenerate clickable letters
                ResetLetters();
            }
        }
    }

    /// <summary>
    /// Generate letters in random position from the response word
    /// </summary>
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

    /// <summary>
    /// Reset all letters in the response, destroy all clicable letters left and regenerate them.
    /// </summary>
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

    /// <summary>
    /// Check if a number is already in the stock list. If not, add it.
    /// </summary>
    /// <param name="number">number to check</param>
    /// <returns>tru if the number exists, false otherwise.</returns>
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

    /// <summary>
    /// Increment the number of clicked letters
    /// </summary>
    public void incIndex()
    {
        index++;
    }

    /// <summary>
    /// retreive a list of id of all instances of clickable letters left
    /// </summary>
    /// <returns>List of id</returns>
    public List<int> GetInstancesList()
    {
        return emptyBoxInstancesId;
    }

    /// <summary>
    /// Add a char (clicked letter) to the answer string
    /// </summary>
    /// <param name="s">The char clicked</param>
    public void addCharToAnswer(string s)
    {
        answer += s;
    }
}
