using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3 : MonoBehaviour
{
    // Liste contenant les reponses de la ligne 3
    List<string> thirdChoice = new List<string>() { "Pablo Picasso", "1764", "1492", "Italie", "Albert Einstein" };

    void Start()
    {

    }

    void Update()
    {
        // Affiche la reponse en fonction de la question
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = thirdChoice[TextControl.randQuestion];
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
