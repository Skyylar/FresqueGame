using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLetters : MonoBehaviour {

    public GameObject letters;
    private GameMaster gM;
    public int index;


    private List<int> indexEmpty;

	// Use this for initialization
	void Start () {
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        indexEmpty = new List<int>();
        indexEmpty = gM.GetInstancesList();
        index = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        index = gM.index;
        Debug.Log(indexEmpty[index].ToString());
        string currentLetter = letters.transform.GetChild(0).GetComponent<TextMesh>().text;
        GameObject.Find(indexEmpty[index].ToString()).transform.GetChild(0).GetComponent<TextMesh>().text = currentLetter;
        gM.incIndex();
        gM.addCharToAnswer(currentLetter);
        Destroy(letters);
    }
}
