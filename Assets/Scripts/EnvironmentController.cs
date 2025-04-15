using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public float speed = 10f; // Speed of the environment's movement

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Calculate the opposite movement direction
        Vector3 direction = new Vector3(-moveHorizontal, 0, -moveVertical).normalized;

        // Move the environment in the opposite direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}

