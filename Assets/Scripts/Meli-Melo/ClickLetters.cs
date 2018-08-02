using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLetters : MonoBehaviour {

    public GameObject letters;
    public int index;

    private GameMaster gM;
    private List<int> indexEmpty;

    /// <summary>
    /// Retrieve game master and list of gameobject name of letters
    /// </summary>
    void Start () {
        gM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        indexEmpty = new List<int>();
        indexEmpty = gM.GetInstancesList();
        index = 0;
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
