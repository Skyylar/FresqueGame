using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class buttonscript : MonoBehaviour {


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
