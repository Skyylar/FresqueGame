using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2 : MonoBehaviour
{
    // Liste contenant les reponses de la ligne 2
    List<string> secondChoice = new List<string>() { "Léonard de Vinci", "1790", "1486", "Belgique", "Isaac Newton" };

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Affiche la reponse en fonction de la question
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = secondChoice[TextControl.randQuestion];
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
