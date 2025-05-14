using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); // loads the main scene when click play 
    }

    public void QuitGame()
    {
        Application.Quit(); // it only works in , when finally build it using build settings in unity 
    }
}
