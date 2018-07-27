using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3 : MonoBehaviour
{

    List<string> thirdChoice = new List<string>() { "Third choice question 1", "Third choice question 2", "Third choice question 3", "Third choice question 4", "Third choice question 5" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<TextMesh>().text = thirdChoice[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = thirdChoice[TextControl.randQuestion];
        }
    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
