using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour 
{

    // Start Games function
    public void startGames() => SceneManager.LoadScene("friscene", LoadSceneMode.Single);

}
