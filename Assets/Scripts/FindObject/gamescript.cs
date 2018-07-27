using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class gamescript : MonoBehaviour {

	public string background;

	public List<string> listTrue = new List<string>(5);
	public List<string> listFalse = new List<string>(5);

	private Texture myBackground;
	private Texture objTrue;
	private Texture objFalse;

	// Use this for initialization
	void Start () {
		LoadBackground();
		//LoadObjects();
		LoadList();
	}

	// Update is called once per frame
	void Update () {

	}

	void LoadList () {
		string list;
		int i;
		for(i=0;i<5;i++) {
			list = listTrue[i];
			GameObject text = GameObject.Find ("ListObject" + i.ToString());
			text.GetComponent<UnityEngine.UI.Text>().text = list;
		}
	}

	void LoadBackground () {
		// chargement du background depuis le dossier resource
		myBackground = Resources.Load ("Images/" + background) as Texture;

		GameObject rawImage = GameObject.Find ("Game");
		rawImage.GetComponent<RawImage>().texture = myBackground;
	}

	void LoadObjects () {
		//Chargement des objets
		int i;
		List<int> location = new List<int>(10);
		for(i=0;i<10;i++)
			location.Add(i);
		for(i=0;i<5;i++) {
			GetTrueObjects(location, i, listTrue);
			GetFalseObjects(location);
		}
	}

	void GetTrueObjects(List<int> location, int i, List<string> listTrue) {
		System.Random rnd = new System.Random();
		int checkTrue = rnd.Next(10);
		int j = 0;
		//Attribution emplacement true
		while(j<1) {
			if(location.Contains(checkTrue)){
				location.Remove(checkTrue);
				j++;
			} else {
				checkTrue = rnd.Next(10);
			}
		}
		//Chargement images true
		string NbTrue = checkTrue.ToString();
		objTrue = Resources.Load ("Images/True_Objects/" + listTrue[i]) as Texture;
		GameObject rawImageTrue = GameObject.Find ("Object_" + NbTrue);
		rawImageTrue.GetComponent<RawImage>().texture = objTrue;
	}

	void GetFalseObjects (List<int> location) {
		//Attribution emplacement false
		System.Random test = new System.Random();
		int checkFalse = test.Next(10);
		int k = 0;
		while(k<1) {
			if(location.Contains(checkFalse)){
				location.Remove(checkFalse);
				k++;
			} else {
				checkFalse = test.Next(10);
			}
		}
		//Chargement images false
		string NbFalse = checkFalse.ToString();
		objFalse = Resources.Load ("Images/False_Objects/" + NbFalse) as Texture;
		GameObject rawImageFalse = GameObject.Find ("Object_" + NbFalse);
		rawImageFalse.GetComponent<RawImage>().texture = objFalse;
	}
}
