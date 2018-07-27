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

	public void OnClickObject () {

		int i;

		gamescript OtherScript = GameObject.Find("gamescript").GetComponent<gamescript>();
		List<String> ListTrue = OtherScript.listTrue;

		for(i=0;i<5;i++) {
			GameObject text = GameObject.Find ("ListObject" + i.ToString());
			if(text.GetComponent<Text>().text == ListTrue[i]) {
				text.GetComponent<Text>().text = "";
				GameObject myButton = GameObject.Find("Obj" + i.ToString());

				myButton.GetComponent<Button>().interactable = false;
				Debug.Log("Bravo vous avez trouvé un mot.");
			}
		}
	}
}
