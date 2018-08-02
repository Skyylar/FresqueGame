using UnityEngine.UI;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gamescript : MonoBehaviour {

	public static float TimeG;
	public static bool timerstarted = true;

	public string background;

	public List<string> listTrue = new List<string>(5);

	private Texture myBackground;
	private Texture objTrue;
	private Texture objFalse;

	private float score;

	// Use this for initialization
	void Start () {
		LoadBackground();
		LoadObjects();
		LoadList();
	}

	// Update is called once per frame
	void Update () {
		if (timerstarted == true) {
				TimeG += Time.deltaTime;
		}

		int f;
		int count = 0;
		for(f=0;f<5;f++) {
			GameObject text = GameObject.Find ("ListObject" + f.ToString());
			string check = text.GetComponent<TextMesh>().text;
			if(check == "") {
				count++;
			}
			if(count == 5) {
				timerstarted = false;
				if(score == 0) {
					score = Map(TimeG, 90, 10, 0, 20);
                    if (score > 20)
                    {
                        score = 20;
                    }
                    GameManager.NoteFindObject = (int)score;
					GameManager.NumberNote += 1;
				}
			}
		}
	}

	private float Map(float x, int in_min,int in_max,int out_min,int out_max)
	{
			return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}

	private void LoadList () {
		string list;
		int i;
		for(i=0;i<5;i++) {
			list = listTrue[i];
			GameObject text = GameObject.Find ("ListObject" + i.ToString());
			text.GetComponent<TextMesh>().text = list;
		}
	}

	private void LoadBackground () {
		// chargement du background depuis le dossier resource
		myBackground = Resources.Load ("Images/FindObject/" + background) as Texture;

		GameObject rawImage = GameObject.Find ("Game");
		rawImage.GetComponent<RawImage>().texture = myBackground;
	}

	private void LoadObjects () {
		//Chargement des objets
		int i;
		List<int> location = new List<int>(10);
		List<int> listFalse = new List<int>(5);
		for(i=0;i<10;i++)
			location.Add(i);
		for(i=0;i<5;i++)
			listFalse.Add(i);
		for(i=0;i<5;i++) {
			GetTrueObjects(location, i, listTrue);
			GetFalseObjects(location, listFalse);
		}
	}

	private void GetTrueObjects(List<int> location, int i, List<string> listTrue) {
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
		objTrue = Resources.Load ("Images/FindObject/True_Objects/" + listTrue[i]) as Texture;
		GameObject rawImageTrue = GameObject.Find ("Object_" + NbTrue);
		rawImageTrue.GetComponent<RawImage>().texture = objTrue;
		GameObject buttonTrue = GameObject.Find ("Obj" + NbTrue);
		buttonTrue.GetComponent<TextMesh>().text = listTrue[i];

	}

	private void GetFalseObjects (List<int> location, List<int> listFalse) {
		//Attribution emplacement false
		System.Random test = new System.Random();
		int checkFalse = test.Next(10);
		int getImage = test.Next(5);
		int k = 0;
		int x = 0;
		while(k<1) {
			if(location.Contains(checkFalse)){
				location.Remove(checkFalse);
				while(x<1) {
					if(listFalse.Contains(getImage)) {
						listFalse.Remove(getImage);
						x++;
					} else {
						getImage = test.Next(5);
					}
				}
				k++;
			} else {
				checkFalse = test.Next(10);
			}
		}
		//Chargement images false
		string NbFalse = checkFalse.ToString();
		string NumObj = getImage.ToString();
		objFalse = Resources.Load ("Images/FindObject/False_Objects/" + NumObj) as Texture;
		GameObject rawImageFalse = GameObject.Find ("Object_" + NbFalse);
		rawImageFalse.GetComponent<RawImage>().texture = objFalse;
	}
}
