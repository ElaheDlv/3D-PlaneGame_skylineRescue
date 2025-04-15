using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

[System.Serializable]
public class DifficultyLevel
{
    public int HighestScore;
    public string TimeAllowed;
    public string SpeedLimit;
    public string TopPlayer;
}

[System.Serializable]
public class GameSettings
{
    public static int EasyHighestScore;
    public static string EasyTimeAllowed;
    public static string EasySpeedLimit;
    public static string EasyTopPlayer;

    public static int MediumHighestScore;
    public static string MediumTimeAllowed;
    public static string MediumSpeedLimit;
    public static string MediumTopPlayer;

    public static int HardHighestScore;
    public static string HardTimeAllowed;
    public static string HardSpeedLimit;
    public static string HardTopPlayer;

    public DifficultyLevel Easy;
    public DifficultyLevel Medium;
    public DifficultyLevel Hard;

    // Method to load data into static variables
    public void LoadStaticVariables()
    {
        // Easy
        EasyHighestScore = Easy.HighestScore;
        EasyTimeAllowed = Easy.TimeAllowed;
        EasySpeedLimit = Easy.SpeedLimit;
        EasyTopPlayer = Easy.TopPlayer;

        // Medium
        MediumHighestScore = Medium.HighestScore;
        MediumTimeAllowed = Medium.TimeAllowed;
        MediumSpeedLimit = Medium.SpeedLimit;
        MediumTopPlayer = Medium.TopPlayer;

        // Hard
        HardHighestScore = Hard.HighestScore;
        HardTimeAllowed = Hard.TimeAllowed;
        HardSpeedLimit = Hard.SpeedLimit;
        HardTopPlayer = Hard.TopPlayer;
    }
}

public class PlayerDataManager : MonoBehaviour
{
    public TMP_Text highestScoreText;  // Reference to TextMesh Pro for highest score
    public TMP_Text timeAllowedText;    // Reference to TextMesh Pro for time allowed
    public TMP_Text speedLimitText;     // Reference to TextMesh Pro for speed limit
    public TMP_Text topPlayerText;

    private GameSettings gameSettings;

    void Start()
    {
        LoadJsonData();
    }

    void LoadJsonData()
    {
        // Define the path to the JSON file in the StreamingAssets folder
        //string filePath = "/home/feezakk/skyline_rescue/Assets/Scripts/PlayerData.json";

        string filePath = Application.dataPath + "/Scripts/PlayerData.json";

        if (File.Exists(filePath))
        {
            // Read the JSON file content
            string jsonData = File.ReadAllText(filePath);

            // Deserialize the JSON data into the GameSettings object
            gameSettings = JsonUtility.FromJson<GameSettings>(jsonData);
            gameSettings.LoadStaticVariables();
        }
        else
        {
            Debug.LogError("JSON file not found at path: " + filePath);
        }
    }
}
