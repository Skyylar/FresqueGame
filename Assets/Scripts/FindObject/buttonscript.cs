using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class buttonscript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	//Bouton retour menu
	public void back_menu () {
		SceneManager.LoadScene("friscene", LoadSceneMode.Single);
	}

	public void OnClickObject (Button button) {

		int i;
		gamescript gScript = GameObject.Find("Game").GetComponent<gamescript>();

		for(i=0;i<5;i++) {
			GameObject text = GameObject.Find ("ListObject" + i.ToString());
			if(button.GetComponent<TextMesh>().text == text.GetComponent<TextMesh>().text) {
					text.GetComponent<TextMesh>().text = "";
					button.interactable = false;
					i = 6;
			}
		}
		if(i == 5) {
				gScript.malus += 1;
		}
	}
}
