using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{

    List<string> firstChoice = new List<string>() { "First choice question 1", "First choice question 2", "First choice question 3", "First choice question 4", "First choice question 5" };

    // Use this for initialization
    void Start()
    {
        //GetComponent<TextMesh>().text = firstChoice[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControl.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = firstChoice[TextControl.randQuestion];
        }
    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
