using UnityEngine;

public class SavePeople : MonoBehaviour
{   
      // Set the name of the object you want to detect collisions with
    public string targetObjectName = "Plane";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object's name matches the specified name
        if (other.gameObject.name == targetObjectName)
        {
            // Make the prefab disappear
            gameObject.SetActive(false);
        }
    }
}