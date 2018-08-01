using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2 : MonoBehaviour
{

    List<string> secondChoice = new List<string>() { "Léonard de Vinci", "1790", "1486", "Belgique", "Isaac Newton" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<TextMesh>().text = secondChoice[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = secondChoice[TextControl.randQuestion];
        }
    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
