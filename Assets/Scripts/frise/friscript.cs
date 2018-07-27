using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class friscript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	//Start prehistoire
	public void Start_Prehistoire() {
		Debug.Log("Vous avez cliqué sur le bouton prehistoire.");
		SceneManager.LoadScene("FindObject", LoadSceneMode.Single);
	}

	//Start antiquite
	public void Start_Antiquite() {
		Debug.Log("Vous avez cliqué sur le bouton antiquite.");
		SceneManager.LoadScene("Puzzle", LoadSceneMode.Additive);
	}

	//Start moyen-age
	public void Start_Moyen_Age() {
		Debug.Log("Vous avez cliqué sur le bouton moyen-age.");
		SceneManager.LoadScene("WordGame", LoadSceneMode.Single);
	}

	//Start temps modernes
	public void Start_Temps_Modernes() {
		Debug.Log("Vous avez cliqué sur le bouton temps modernes.");
		SceneManager.LoadScene("quiz", LoadSceneMode.Single);
	}

	//Start XIXeme siecle
	public void Start_XIX_siecle() {
		Debug.Log("Vous avez cliqué sur le bouton XIXeme siecle.");
		//SceneManager.LoadScene("XIX_siecle", LoadSceneMode.Single);
	}

	//Start XXeme siecle
	public void Start_XX_siecle() {
		Debug.Log("Vous avez cliqué sur le bouton XXeme siecle.");
		//SceneManager.LoadScene("XX_siecle", LoadSceneMode.Single);
	}
}
