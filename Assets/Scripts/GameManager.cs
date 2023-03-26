using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // public variables
    public static int score = 0;    // Score of the player
    public static int lives = 3;    // Lives of the player

    // private variables
    // score text
    private static Text scoreText;
    // lives text
    private static Text livesText;
    // game over text
    private static Text gameOverText;


    // Start is called before the first frame update
    void Start()
    {
        // get score, lives and game over text
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        scoreText.text = "Score: " + score;     // Show the score
        livesText.text = "Lives: " + lives;     // Show the lives
        gameOverText.gameObject.SetActive(false);   // Hide the game over text
    }
    
    static void GameOver()
    {
        Time.timeScale = 0;     // Stop the game
        PlayerController.SetGameOver();     // set isGameOver to true
        // set gameOverText active
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over!";   // Show the game over text
    }

    public static void IncrementScore(int scoreIncrement)
    {
        score += scoreIncrement;
        // Debug.Log("Lives: " + lives + " Score: " + score);
        scoreText.text = "Score: " + score;     // Show the score
    }

    public static void DecrementLives()
    {
        if (lives > 0)
        {
            lives--;
            // Debug.Log("Lives: " + lives + " Score: " + score);
            livesText.text = "Lives: " + lives;
        }
        else if (lives <= 0)
        {
            // Debug.Log("Lives: " + lives + " Score: " + score);
            GameOver();
        }
    }
}
