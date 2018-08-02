using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour 
{

    // Load scene 'Friscene'
    public void startGames() => SceneManager.LoadScene("friscene", LoadSceneMode.Single);

}
