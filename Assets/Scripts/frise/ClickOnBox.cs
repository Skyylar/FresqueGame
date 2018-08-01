using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOnBox : MonoBehaviour {

    public Transform box;
    private new string name = "";
	// Use this for initialization
	void Start () {
        name = box.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Type type = this.GetType();
        MethodInfo call = type.GetMethod("Start_"+name);
        call.Invoke(this, new object[] { });
    }

    //Start prehistoire
    public void Start_Prehistoire()
    {
        SceneManager.LoadScene("FindObject", LoadSceneMode.Single);
    }

    //Start antiquite
    public void Start_Antiquite()
    {
        SceneManager.LoadScene("Puzzle", LoadSceneMode.Single);
    }

    //Start moyen-age
    public void Start_MoyenAge()
    {
        SceneManager.LoadScene("WordGame", LoadSceneMode.Single);
    }

    //Start temps modernes
    public void Start_TempsModernes()
    {
        SceneManager.LoadScene("quiz", LoadSceneMode.Single);
    }

    //Start XIXeme siecle
    public void Start_XIXSiecle()
    {
        GameManager.VideoName = "video1.mp4";
        SceneManager.LoadScene("videoPlayer", LoadSceneMode.Single);
    }

    //Start XXeme siecle
    public void Start_XXSiecle()
    {
        GameManager.VideoName = "video2.mp4";
        SceneManager.LoadScene("videoPlayer", LoadSceneMode.Single);
    }

}
