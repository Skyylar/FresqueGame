using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TextControl : MonoBehaviour
{

    static List<string> questions = new List<string>() { "This is the first question", "This is the second question", "This is the third question", "This is the fourth question", "This is the fifth question" };

    List<string> correctAnswer = new List<string>() { "1", "2", "3", "4", "4" };

    List<int> previousQuestions = new List<int>() { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
    public int questionNumber = 0;

    public Transform resultObj;

    public Transform nextObj;

    public static string selectedAnswer;

    public static string choiceSelected = "n";
    public static int nextActivator = 0;

    public static int randQuestion = -1;

    public static int totalCorrect = 0;

    public static int totalQuestions = 0;

    public int sizeList = questions.Count;

    public static int i = 0;

    // Use this for initialization
    void Start()
    {
        resultObj.GetComponent<TextMesh>().text = "";
        nextObj.GetComponent<TextMesh>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (randQuestion == -1)
        {
            randQuestion = Random.Range(0, 5);
            for (int j = 0; j < 22; j++)
            {
                if (randQuestion != previousQuestions[j])
                {

                }
                else
                {
                    randQuestion = -1;
                }
            }
        }

        if (randQuestion > -1)
        {
            GetComponent<TextMesh>().text = questions[randQuestion];
            previousQuestions[questionNumber] = randQuestion;
        }
        
        if (choiceSelected == "y")
        {
            choiceSelected = "n";
            totalQuestions += 1;
            questionNumber += 1;
            nextActivator = 1;
            if ( nextActivator == 1)
            {
                if (correctAnswer[randQuestion] == selectedAnswer)
                {
                    resultObj.GetComponent<TextMesh>().text = "Correct !";
                    nextObj.GetComponent<TextMesh>().text = "Suivant";
                    totalCorrect += 1;
                    i++;
                    
                    if (i == sizeList)
                    {
                        SceneManager.LoadScene("Score");
                    }
                }
                else if (correctAnswer[randQuestion] != selectedAnswer)
                {
                    resultObj.GetComponent<TextMesh>().text = "Incorrect !";
                    nextObj.GetComponent<TextMesh>().text = "Suivant";
                    i++;
                    if (i == sizeList)
                    {
                        SceneManager.LoadScene("Score");
                    }
                }
            }
        }
    }

}
