using UnityEngine;
using TMPro;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Assign in Inspector (e.g. 5 entries)
    private int[] highScores = new int[5];

    void Start()
    {
        LoadScores();
        DisplayScores();
    }

    // Call this method when the game ends and you have a new score
    public void AddScore(int newScore)
    {
        // Insert new score and sort
        highScores[4] = newScore;
        highScores = highScores.OrderByDescending(s => s).ToArray();
        SaveScores();
        DisplayScores();
    }

    void LoadScores()
    {
        for (int i = 0; i < highScores.Length; i++)
            highScores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
    }

    void SaveScores()
    {
        for (int i = 0; i < highScores.Length; i++)
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
    }

    void DisplayScores()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (scoreTexts[i] != null)
                scoreTexts[i].text = $"{i + 1}. {highScores[i]}";
        }
    }

    // Optional: To clear the leaderboard (for testing)
    public void ClearLeaderboard()
    {
        for (int i = 0; i < highScores.Length; i++)
            PlayerPrefs.DeleteKey("HighScore" + i);
        LoadScores();
        DisplayScores();
    }
}
