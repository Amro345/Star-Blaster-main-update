using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
   

    private void Start()
    {
    }

    private void OnStartButtonClick()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Load the scene named "GameScene"
    }
}
