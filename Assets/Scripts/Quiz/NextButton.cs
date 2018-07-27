using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {

    public Transform resultObj;

    public Transform nextObj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        TextControl.nextActivator = 0;
        TextControl.randQuestion = -1;
        resultObj.GetComponent<TextMesh>().text = "";
        nextObj.GetComponent<TextMesh>().text = ""; 
    }
}
