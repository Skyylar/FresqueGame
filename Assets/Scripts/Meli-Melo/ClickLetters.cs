using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLetters : MonoBehaviour {

    public GameObject letters;
    public int index;

    private GameMaster gM;
    private List<int> indexEmpty;

    // Use this for initialization
    void Start () {
        //Initialize variable
        indexEmpty = new List<int>();
        index = 0;

        //Retrieve game master object
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        //Retrieve list of clickable letters        
        indexEmpty = gM.GetInstancesList();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// When a letter is clicked, remove it object, pass it value to the game master and increment index
    /// </summary>
    private void OnMouseDown()
    {
        index = gM.index;
        string currentLetter = letters.transform.GetChild(0).GetComponent<TextMesh>().text;
        GameObject.Find(indexEmpty[index].ToString()).transform.GetChild(0).GetComponent<TextMesh>().text = currentLetter;
        gM.incIndex();
        gM.addCharToAnswer(currentLetter);
        Destroy(letters);
    }
}
