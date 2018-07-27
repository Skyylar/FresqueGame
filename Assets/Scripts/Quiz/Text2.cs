using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2 : MonoBehaviour
{

    List<string> secondChoice = new List<string>() { "Second choice question 1", "Second choice question 2", "Second choice question 3", "Second choice question 4", "Second choice question 5" };

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
