using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text4 : MonoBehaviour
{

    List<string> fourthChoice = new List<string>() { "Fourth choice question 1", "Fourth choice question 2", "Fourth choice question 3", "Fourth choice question 4", "Fourth choice question 5" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<TextMesh>().text = fourthChoice[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = fourthChoice[TextControl.randQuestion];
        }
    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
