using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOnBox : MonoBehaviour {

    // Clickable object
    public Transform box;

    // name of the object
    private new string[] name;


	// Use this for initialization
	void Start () {
        name = box.GetChild(0).name.Split(' ');
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Call correct scene when clicking on a period
    /// </summary>
    private void OnMouseDown()
    {
        if (name.Length == 2)
            GameManager.VideoName = name[1]+".mp4";
        SceneManager.LoadScene(name[0], LoadSceneMode.Single);
    }

}
