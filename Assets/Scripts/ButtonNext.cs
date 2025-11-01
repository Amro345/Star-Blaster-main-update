using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnStartButtonClick()
    {

    }
    public void nextlevel()
    {
        SceneManager.LoadScene("Level2"); // Load the scene named "GameScene"
    }
}
