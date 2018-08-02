using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    // Liste contenant les questions
    static List<string> questions = new List<string>() { "Qui a peint la Joconde ?", "Quand ont lieu les premiers vols en montgolfière ?", "Quand Christophe Colomb a-t-il découvert l'Amérique?", "Louis XIV a été roi de quel pays ?", "Qui a inventé la Machine à vapeur ?" };

    // Liste contenant la reponse aux questions en fonction de ou elle se situe
    public static List<string> correctAnswer = new List<string>() { "2", "1", "3", "4", "1" };

    // Liste stockant les precedentes questions pour les retirer de la liste
    List<int> previousQuestions = new List<int>() { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};

    // Stockage du nombre de question deja passé
    public int questionNumber = 0;

    // Transform permettant d'afficher si la question est validé ou non
    public Transform resultObj;

    // Transform permettant d'afficher le bouton de question suivante
    public Transform nextObj;

    // Récupere la réponse selectionné
    public static string selectedAnswer;

    public static string choiceSelected = "n";

    public static int nextActivator = 0;

    public static int randQuestion = -1;

    public static int totalCorrect = 0;

    public static int totalQuestions = 0;

    public static int isClicked = 0;

    public int sizeList = questions.Count;

    public static int i = 0;

    // Initialise le resultat de la question et le bouton suivant a vide
    void Start()
    {
        resultObj.GetComponent<TextMesh>().text = "";
        nextObj.GetComponent<TextMesh>().text = "";
    }

    void Update()
    {
        // Check si la question est a -1 et fait un random sur la taille de la liste
        // Si la question choisi est deja dans les questions precedentes relance un random
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

        // Quand la question a ete selectionné
        // l'affiche et la stock dans les questions precedentes
        if (randQuestion > -1)
        {
            GetComponent<TextMesh>().text = questions[randQuestion];
            previousQuestions[questionNumber] = randQuestion;
        }

        // Le choix a ete selectionné
        if (choiceSelected == "y")
        {
            // On repasse le choix a N et on incremente les differentes variables
            choiceSelected = "n";
            totalQuestions += 1;
            questionNumber += 1;
            nextActivator = 1;
            // Affiche le resultat et le bouton suivant et si les questions sont tous passé, affiche le score
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
