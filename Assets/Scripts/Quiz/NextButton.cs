using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {

    public Transform resultObj;

    public Transform nextObj;

    void OnMouseDown()
    {
        // Au clique sur le bouton suivant remet a 0 les variables
        TextControl.nextActivator = 0;
        TextControl.randQuestion = -1;
        TextControl.isClicked = 0;
        resultObj.GetComponent<TextMesh>().text = "";
        nextObj.GetComponent<TextMesh>().text = "";
    }
}
