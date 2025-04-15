using UnityEngine;
using UnityEngine.UI;
using System.IO; // For file handling
using TMPro; // Correct namespace for TextMeshPro
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float totalTime; // Total time for the game in seconds
    private float remainingTime;
    public TextMeshProUGUI TimerText; // Reference to the UI Text element to display the timer
    //public TextMeshProUGUI Info;

    private bool isGameOver = false;
    private string jsonFilePath;
    public GameObject gameOverPanel;

    // Add AudioSource references for each sound effect
    public AudioSource backgroundMusic;      // Line to add for background music
    public AudioSource gameOverSoundSource;  // Line to add for Game Over sound

    void Start()
    {
        // Initialize totalTime with the value from HUDController
        totalTime = HUDController.timeAllowed;
        remainingTime = totalTime;

        // Set the path for the JSON file
        jsonFilePath = Application.dataPath + "/Scripts/PlayerData.json";
        //jsonFilePath = "/home/feezakk/skyline_rescue/Assets/Scripts/PlayerData.json";

        SaveGameSettings();

    }

    void Update()
    {
        if (!isGameOver)
        {
            // Countdown the time
            remainingTime -= Time.deltaTime;

            // Update the timer display
            TimerText.text = "Time: " + Mathf.Ceil(remainingTime).ToString();

            // Check if the time is up
            if (remainingTime <= 0)
            {
                GameOver();
            }
        }

        SaveGameSettings();
    }

    void GameOver()
    {
        isGameOver = true;
        remainingTime = 0;
        TimerText.text = "Time: 0"; // Update the timer text to show 0
        Debug.Log("Game Over! Time is up.");

        int currentScore = PlaneCollisionHandler.people;

        if (DifficultyDropdownController.selectedDifficulty == "Easy")
        {
            if (currentScore > GameSettings.EasyHighestScore) // Modify for difficulty if needed
            {
                Debug.Log("New high score! Updating JSON...");

                GameSettings.EasyHighestScore = currentScore;
                GameSettings.EasyTopPlayer = MainMenuController.playerName; // Replace with actual player name

                // Save the updated settings to the JSON file
                SaveGameSettings();
            }
        }

        if (DifficultyDropdownController.selectedDifficulty == "Medium")
        {
            if (currentScore > GameSettings.MediumHighestScore) // Modify for difficulty if needed
            {
                Debug.Log("New high score! Updating JSON...");

                GameSettings.MediumHighestScore = currentScore;
                GameSettings.MediumTopPlayer = MainMenuController.playerName; // Replace with actual player name

                // Save the updated settings to the JSON file
                SaveGameSettings();
            }
        }

        if (DifficultyDropdownController.selectedDifficulty == "Hard")
        {
            if (currentScore > GameSettings.HardHighestScore) // Modify for difficulty if needed
            {
                Debug.Log("New high score! Updating JSON...");

                GameSettings.HardHighestScore = currentScore;
                GameSettings.HardTopPlayer = MainMenuController.playerName; // Replace with actual player name

                // Save the updated settings to the JSON file
                SaveGameSettings();
            }
        }
        
        StartCoroutine(ShowGameOverAfterDelay(0));
        // Call the GameManager's GameOver method if you have one
        //FindObjectOfType<GameManager>().GameOver();
    }

    private IEnumerator ShowGameOverAfterDelay(float delay)
    {
        // Wait for the explosion to complete
        yield return new WaitForSeconds(delay);
        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            // Play Game Over sound when Game Over panel is shown
            if (gameOverSoundSource != null)   
            {                                  
                gameOverSoundSource.Play();    
            }                                  

            // Stop background music when Game Over panel is shown (optional)
            if (backgroundMusic != null)       
            {                                  
                backgroundMusic.Stop();        
            }                                  
        }
        else
        {
            Debug.LogWarning("Game Over panel is not assigned!");
        }
    }

      public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit(); // This will close the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
        #endif
    }

    public void RetryGame()
    {
        Debug.Log("Retry button pressed");

                // Optional: Stop the Game Over sound when retrying
        if (gameOverSoundSource != null)      
        {                                     
            gameOverSoundSource.Stop();       
        }                                     

        // Restart background music when retrying the game
        if (backgroundMusic != null)          
        {                                     
            backgroundMusic.Play();           
        }  

        ///////////////// the below line should change to go through the main page ////////////////////// 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }

    void SaveGameSettings()
    {
        // Serialize the GameSettings object to JSON
        string jsonData = JsonUtility.ToJson(new GameSettings
        {
            Easy = new DifficultyLevel
            {
                HighestScore = GameSettings.EasyHighestScore,
                TopPlayer = GameSettings.EasyTopPlayer,
                TimeAllowed = GameSettings.EasyTimeAllowed,
                SpeedLimit = GameSettings.EasySpeedLimit
            },
            Medium = new DifficultyLevel
            {
                HighestScore = GameSettings.MediumHighestScore,
                TopPlayer = GameSettings.MediumTopPlayer,
                TimeAllowed = GameSettings.MediumTimeAllowed,
                SpeedLimit = GameSettings.MediumSpeedLimit
            },
            Hard = new DifficultyLevel
            {
                HighestScore = GameSettings.HardHighestScore,
                TopPlayer = GameSettings.HardTopPlayer,
                TimeAllowed = GameSettings.HardTimeAllowed,
                SpeedLimit = GameSettings.HardSpeedLimit

            }
        });


        //Info.text = jsonData;

        Debug.Log(jsonData);

        // Write the updated JSON data to the file
        File.WriteAllText(jsonFilePath, jsonData);
    }
}
