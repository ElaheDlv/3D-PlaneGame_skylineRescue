using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaneCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI PeopleText; // UI text to display score
    //public int people = 0;
    // Reference to the explosion prefab and Game Over panel
    public GameObject explosionPrefab;
    public GameObject gameOverPanel;
    
    public static int people = 0; // Increase score by 10 for each fuel point

    // Add AudioSource references for each sound effect
    public AudioSource backgroundMusic;      // Line to add for background music
    public AudioSource explosionSoundSource; // Line to add for explosion sound
    public AudioSource gameOverSoundSource;  // Line to add for Game Over sound
    
    public GameObject QuitButton;
    public GameObject RetryButton;
    public GameObject QuitButtonMainGame;

    // Set the delay to match the explosion's duration
    public float explosionDuration = 2.0f;  // Adjust this to match the explosion effect's duration


    public void Start()
    {
        // Start playing background music at the start of the game
        if (backgroundMusic != null)         
        {                                    
            backgroundMusic.Play();          
        }                                    
    }

    public void OnCollisionEnter(Collision collision)
    {

        
        //Debug.LogWarning("Collision detected with object: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Terrain"))
        {
            //Debug.LogError("Plane collided with: " + collision.gameObject.name);

            // Trigger the explosion effect at the plane's position
             // Play the explosion sound upon collision
            if (explosionSoundSource != null) 
            {                                 
                explosionSoundSource.Play();  
            }                                 

            TriggerExplosion(transform.position);

            // Start the coroutine to show Game Over after the explosion duration
            StartCoroutine(ShowGameOverAfterDelay(explosionDuration));
        }
    }

    public void TriggerExplosion(Vector3 position)
    {
        if (explosionPrefab != null)
        {
            // Instantiate the explosion at the collision point
            GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

            // Optional: Scale the explosion if needed
            explosion.transform.localScale *= 2.0f;  // Adjust the multiplier as needed
        }
        else
        {
            Debug.LogWarning("Explosion prefab is not assigned!");
        }
    }

    public IEnumerator ShowGameOverAfterDelay(float delay)
    {
        // Wait for the explosion to complete
        yield return new WaitForSeconds(delay);

        QuitButtonMainGame.gameObject.SetActive(false);

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
    
    public void HandleQuitButtonPress()
    {
        StartCoroutine(ShowGameOverAfterDelay(0));
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
        
        people = 0;

        ///////////////// the below line should change to go through the main page ////////////////////// 
        SceneManager.LoadScene("New Scene"); // Reloads the current scene

       // Subscribe to the sceneLoaded event
       //SceneManager.sceneLoaded += OnNewSceneLoaded;
    }

    /*
    // This method is called when the new scene is fully loaded
    private void OnNewSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // Remove the listener to avoid calling this function multiple times
       SceneManager.sceneLoaded -= OnNewSceneLoaded;

       // Access the Canvas object in the new scene (assuming it's called "Canvas" or adjust accordingly)
       Canvas canvas = FindObjectOfType<Canvas>(); // Finds the first Canvas in the scene

       if (canvas != null)
       {
            // Access the CanvasScaler component attached to the Canvas
            CanvasScaler canvasScaler = canvas.GetComponent<CanvasScaler>();
            if (canvasScaler != null)
            {
                // Set UI Scale Mode to Scale With Screen Size
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

                // Set Screen Match Mode to Expand
                canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;

                // Optionally, set the reference resolution for the canvas
                canvasScaler.referenceResolution = new Vector2(1000, 1000); // Example reference resolution
            }
            else
            {
                Debug.LogError("CanvasScaler not found on the Canvas.");
            }
       }
       else
       {
           Debug.LogError("Canvas not found in the new scene.");
       }
       
       Camera mainCamera = Camera.main;
       if (mainCamera != null)
	    {
		mainCamera.fieldOfView = 13.23711f; // Set to the precise FOV value
	    }
	    else
	    {
		Debug.LogError("Main camera not found in the new scene.");
	    }
    }
   
*/

    // This function will be called if you are using trigger-based colliders
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with: " + other.gameObject.name);

        Destroy(other.gameObject, 0.1f);
        
        IncreaseScore();
    }
    
    public void IncreaseScore()
    {
        people += 10; // Increase score by 10 for each fuel point
        PeopleText.text = "People: " + people;
    }
}
