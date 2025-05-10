using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager instance;
    private int score = 0 ; 
    private int highscore = 0 ;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public TextMeshProUGUI newHighScoreText;

    public AudioSource highscoresound;

    private bool hasshownhighscoreffect = false;

    void Awake()
    {
        if(instance == null)
        {
            instance= this;
        }
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void Addscore(int amount){
        score+=amount;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore",highscore);
            if(!hasshownhighscoreffect)
            {
                ShowHighScoreEffect();

                hasshownhighscoreffect = true;
            }
        }
        UpdateUI();

    }

    void UpdateUI(){
        if(scoreText!=null)
        {
            scoreText.text = "Score: " + score;



        }

        if(highscoreText!=null)
        {
            highscoreText.text ="High Score: " + highscore;
        }
        // else
        // {
        //     Debug.LogWarning("ScoreText is not assigned!");
        // }
    }

    public void ResetScore(){
        score = 0 ; 
        UpdateUI();
    }

    void ShowHighScoreEffect(){
        if(newHighScoreText!=null)
        {
            newHighScoreText.gameObject.SetActive(true);
            StartCoroutine(HideHighScoreTextAfterSeconds(2f));

        }
        if(highscoresound!=null)
        {
            highscoresound.Play();
        }
    }

    IEnumerator HideHighScoreTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        newHighScoreText.gameObject.SetActive(false);
    }
    
}
