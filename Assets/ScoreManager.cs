using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float currentScore = 0f;
    public float highScore = 0f;
    public bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        currentScore= 0f;
        isGameOver=false;
        // Load the saved high score when the game starts
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateUI();

    }
    void Update ()
    {
         
        if (!isGameOver)
        {
            // Increment score over time (1 point per second)
            currentScore = currentScore + Time.deltaTime;
            UpdateUI();
        }
    
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateUI();
    }

    // Call this function when the player falls off or hits a bomb
    public void GameOver()
    {
        isGameOver=true;
        // Check if the final score is better than the record
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save(); // Forces the save to disk immediately
        }
        currentScore=0f;
        UpdateUI();
        isGameOver= false;
    }

    void UpdateUI()
    {
        scoreText.text = "SCORE: " + Mathf.FloorToInt(currentScore).ToString();
        highScoreText.text = "HIGH SCORE: " + Mathf.FloorToInt(highScore).ToString();
    }
}