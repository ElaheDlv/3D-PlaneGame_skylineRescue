using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HUDController : MonoBehaviour
{
    public GameObject hudPanel;  // Reference to the HUD panel
    public GameObject controlPanel;  // Reference to the HUD panel
    public GameObject startGame;  // Reference to the HUD panel
    public GameObject quitButton;  // Reference to the HUD panel
    public GameObject difficultyController;  // Reference to the HUD panel
    public GameObject controlButton;  // Reference to the HUD panel
    public GameObject playerName;  // Reference to the HUD panel
    
    //public Text highestScoreText;
    //public Text timeAllowedText;
    //public Text speedRangeText;
    //public Text TopPlayerText;
    
    public TMP_Text highestScoreText;  // Reference to TextMesh Pro for highest score
    public TMP_Text timeAllowedText;    // Reference to TextMesh Pro for time allowed
    public TMP_Text speedRangeText;     // Reference to TextMesh Pro for speed limit
    public TMP_Text TopPlayerText;      // Reference to TextMesh Pro for top player


    public static int timeAllowed = 0;
    public static int speedLimit = 0;
    public static int highestScore = 0;
    public static string highestPlayer = "";

    private PlayerDataManager playerDataManager;  // Reference to PlayerDataManager

    void Start()
    {
        // Get the PlayerDataManager instance
        playerDataManager = FindObjectOfType<PlayerDataManager>();

        if (playerDataManager == null)
        {
            Debug.LogError("PlayerDataManager not found in the scene!");
            return;
        }

        // Hide HUD panel at the start
        hudPanel.SetActive(false);
        controlPanel.SetActive(false);
    }
    
    public void DisplayControl(string difficulty)
    {
    	startGame.SetActive(false);
    	quitButton.SetActive(false);
    	difficultyController.SetActive(false);
    	controlButton.SetActive(false);
    	hudPanel.SetActive(false);
    	playerName.SetActive(false);
        controlPanel.SetActive(true);
    }
    
    public void backControl(string difficulty)
    {
    	startGame.SetActive(true);
    	quitButton.SetActive(true);
    	difficultyController.SetActive(true);
    	controlButton.SetActive(true);
    	hudPanel.SetActive(true);
    	playerName.SetActive(true);
        controlPanel.SetActive(false);
    }

    // This method will be called when the difficulty is selected
    public void DisplayHUD(string difficulty)
    {
        if (playerDataManager == null) return;

        hudPanel.SetActive(true);

        switch (difficulty)
        {
            case "Easy":
                highestScoreText.text = "Highest Score: " + GameSettings.EasyHighestScore;
                timeAllowedText.text = "Time Allowed: " + GameSettings.EasyTimeAllowed;
                speedRangeText.text = "Speed: " + GameSettings.EasySpeedLimit;
                TopPlayerText.text = "Top Player: " + GameSettings.EasyTopPlayer;
                // Parse strings to integers
                int.TryParse(GameSettings.EasyTimeAllowed, out timeAllowed);
                int.TryParse(GameSettings.EasySpeedLimit, out speedLimit);
                
                highestScore = GameSettings.EasyHighestScore;
                break;
            case "Medium":
                highestScoreText.text = "Highest Score: " + GameSettings.MediumHighestScore;
                timeAllowedText.text = "Time Allowed: " + GameSettings.MediumTimeAllowed;
                speedRangeText.text = "Speed: " + GameSettings.MediumSpeedLimit;
                TopPlayerText.text = "Top Player: " + GameSettings.MediumTopPlayer;
                
                // Parse strings to integers
                int.TryParse(GameSettings.MediumTimeAllowed, out timeAllowed);
                int.TryParse(GameSettings.MediumSpeedLimit, out speedLimit);
                
                highestScore = GameSettings.MediumHighestScore;
                break;
            case "Hard":
                highestScoreText.text = "Highest Score: " + GameSettings.HardHighestScore;
                timeAllowedText.text = "Time Allowed: " + GameSettings.HardTimeAllowed;
                speedRangeText.text = "Speed: " + GameSettings.HardSpeedLimit;
                TopPlayerText.text = "Top Player: " + GameSettings.HardTopPlayer;
                
                // Parse strings to integers
                int.TryParse(GameSettings.HardTimeAllowed, out timeAllowed);
                int.TryParse(GameSettings.HardSpeedLimit, out speedLimit);
                
                highestScore = GameSettings.HardHighestScore;
                break;
        }

        Debug.Log("loaded");
    }
}
