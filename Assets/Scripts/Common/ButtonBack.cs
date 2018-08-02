using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBack : MonoBehaviour {

	public void BackToFrise()
    {
        SceneManager.LoadScene("friscene", LoadSceneMode.Single);
    }
}
