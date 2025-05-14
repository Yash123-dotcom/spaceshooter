using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pausemenupanel;
    private bool isPause = false;
    void Start()
    {
        if(pausemenupanel!=null)
            pausemenupanel.SetActive(false);
        
    }

    public void Pausegame()
    {
        isPause = true;
        Time.timeScale = 0f;
        if(pausemenupanel!=null)
        {
            pausemenupanel.SetActive(true);
        }
    }

    public void Resumegame()
    {
        isPause = false;
        Time.timeScale = 1f;

        if(pausemenupanel!=null)
        {
            pausemenupanel.SetActive(false);
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    
}
