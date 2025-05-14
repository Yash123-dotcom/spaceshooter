using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderBoardButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenuPanel;
    public GameObject leaderboardPanel;
    public void Showleaderboard()
    {
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(true);

    }

    public void BacktoMenu()
    {
        leaderboardPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }


}
