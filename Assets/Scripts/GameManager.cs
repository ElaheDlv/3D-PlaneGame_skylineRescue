using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject birdPrefab; // Reference to the bird prefab
    //public GameObject fuelPointPrefab; // Reference to the fuel point prefab
    public TextMeshProUGUI scoreText; // UI text to display score

    private int score = 0;
    private float spawnRate = 2f; // Rate of spawning birds and fuel points

    void Start()
    {
    }


    public void IncreaseScore()
    {
        score += 10; // Increase score by 10 for each fuel point
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // Stop spawning objects
        CancelInvoke("SpawnBird");
        CancelInvoke("SpawnFuelPoint");

        // Store the final score for the Game Over screen
        PlayerPrefs.SetInt("FinalScore", score);

        // Load the Game Over scene
        SceneManager.LoadScene("GameOver");
    }
}

