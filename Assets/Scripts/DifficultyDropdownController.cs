using UnityEngine;
using TMPro;

public class DifficultyDropdownController : MonoBehaviour
{
    public HUDController hudController;  // Reference to the HUDController script

    public TMP_Dropdown difficultyDropdown;  // Reference to the TextMesh Pro Dropdown UI element

    public static string selectedDifficulty = "";

    void Start()
    {
        // Add a listener to call the method when the dropdown value changes
        difficultyDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(difficultyDropdown);
        });
    }

    // Method to handle the dropdown value change
    void DropdownValueChanged(TMP_Dropdown dropdown)
    {
        selectedDifficulty = dropdown.options[dropdown.value].text;

        // Set the difficulty using PlayerPrefs or any other method
        PlayerPrefs.SetString("Difficulty", selectedDifficulty);

        // GameSettings.SetSpeed(selectedDifficulty);

        hudController.DisplayHUD(selectedDifficulty);
    }
}

