using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{
    // Liste contenant les reponses de la ligne 1
    List<string> firstChoice = new List<string>() { "Michel-Ange", "1783", "1495", "Suisse", "Denis Papin" };

    void Start()
    {
        
    }

    void Update()
    {
        // Affiche la reponse en fonction de la question
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = firstChoice[TextControl.randQuestion];
        }
    }

    void OnMouseDown()
    {
        // Si une reponse a ete selectionné empeche de recliquer sur une reponse
        if (TextControl.isClicked == 0)
        {
            TextControl.selectedAnswer = gameObject.name;
            TextControl.choiceSelected = "y";
            TextControl.isClicked = 1;
        }
    }
}
