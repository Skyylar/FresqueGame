using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickOnBox : MonoBehaviour {

    public Transform box;
    private string name;
	// Use this for initialization
	void Start () {
        name = box.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Start_" + name);
        Type type = this.GetType();
        MethodInfo call = type.GetMethod("Start_"+name);
        call.Invoke(this, new object[] { });
    }

    //Start prehistoire
    public void Start_Prehistoire()
    {
        Debug.Log("Vous avez cliqué sur le bouton prehistoire.");
        SceneManager.LoadScene("FindObject", LoadSceneMode.Single);
    }

    //Start antiquite
    public void Start_Antiquite()
    {
        Debug.Log("Vous avez cliqué sur le bouton antiquite.");
        SceneManager.LoadScene("Puzzle", LoadSceneMode.Single);
    }

    //Start moyen-age
    public void Start_MoyenAge()
    {
        Debug.Log("Vous avez cliqué sur le bouton moyen-age.");
        SceneManager.LoadScene("WordGame", LoadSceneMode.Single);
    }

    //Start temps modernes
    public void Start_TempsModernes()
    {
        Debug.Log("Vous avez cliqué sur le bouton temps modernes.");
        SceneManager.LoadScene("quiz", LoadSceneMode.Single);
    }

    //Start XIXeme siecle
    public void Start_XIXSiecle()
    {
        Debug.Log("Vous avez cliqué sur le bouton XIXeme siecle.");
        //SceneManager.LoadScene("XIX_siecle", LoadSceneMode.Single);
    }

    //Start XXeme siecle
    public void Start_XXSiecle()
    {
        Debug.Log("Vous avez cliqué sur le bouton XXeme siecle.");
        //SceneManager.LoadScene("XX_siecle", LoadSceneMode.Single);
    }
}
