using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriseMaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.NoteFindObject != 0)
        {
            GameObject.Find("Prehistoire").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("Prehistoire").GetComponent<MeshCollider>().enabled = false;
            GameObject.Find("Prehistoire").GetComponent<Button>().enabled = false;
            GameObject.Find("Prehistoire").GetComponent<ClickOnBox>().enabled = false;
        }
        if (GameManager.NoteQuiz != 0)
        {
            GameObject.Find("TempsModernes").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("TempsModernes").GetComponent<MeshCollider>().enabled = false;
            GameObject.Find("TempsModernes").GetComponent<Button>().enabled = false;
            GameObject.Find("TempsModernes").GetComponent<ClickOnBox>().enabled = false;
        }
        if (GameManager.NotePuzzle != 0)
        {
            GameObject.Find("Antiquite").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("Antiquite").GetComponent<MeshCollider>().enabled = false;
            GameObject.Find("Antiquite").GetComponent<Button>().enabled = false;
            GameObject.Find("Antiquite").GetComponent<ClickOnBox>().enabled = false;
        }
        if (GameManager.NoteMeliMelo != 0)
        {
            GameObject.Find("MoyenAge").GetComponent<BoxCollider>().enabled = false;
            GameObject.Find("MoyenAge").GetComponent<MeshCollider>().enabled = false;
            GameObject.Find("MoyenAge").GetComponent<Button>().enabled = false;
            GameObject.Find("MoyenAge").GetComponent<ClickOnBox>().enabled = false;
        }
	}
}
