using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{

    List<string> firstChoice = new List<string>() { "Michel-Ange", "1783", "1495", "Suisse", "Denis Papin" };

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
