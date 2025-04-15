
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed = 50f;             // Speed of the plane movement
    public float rotationSpeed = 20f;         // Speed of rotation for pitch, yaw, and roll
    public float strafeSpeed = 30f;           // Speed for strafing left/right or ascending/descending

    void Update()
    {
        // Input for directional movement
        float forwardInput = Input.GetAxis("Vertical");        // W/S for forward/backward
        float strafeInput = Input.GetAxis("Horizontal");       // A/D for strafing left/right
        float liftInput = (Input.GetKey(KeyCode.Space) ? 1 : 0) - (Input.GetKey(KeyCode.LeftShift) ? 1 : 0); // Space/Shift for up/down

        // Apply directional movement based on inputs
        Vector3 moveDirection = transform.forward * forwardInput + transform.right * strafeInput + transform.up * liftInput;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Input for pitch, yaw, and roll
        float pitchInput = (Input.GetKey(KeyCode.I) ? 1 : 0) - (Input.GetKey(KeyCode.K) ? 1 : 0);
        float yawInput = (Input.GetKey(KeyCode.L) ? 1 : 0) - (Input.GetKey(KeyCode.J) ? 1 : 0);
        float rollInput = (Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0);

        // Apply rotations for pitch, yaw, and roll based on inputs
        transform.Rotate(Vector3.right, pitchInput * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, yawInput * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward, -rollInput * rotationSpeed * Time.deltaTime);
    }
}
/*

using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed = 50f;             // Speed of the plane movement
    public float rotationSpeed = 20f;         // Speed of rotation for pitch, yaw, and roll
    public float strafeSpeed = 30f;           // Speed for strafing left/right or ascending/descending

    void Update()
    {
        // Input for directional movement
        float forwardInput = Input.GetAxis("Vertical");        // W/S for forward/backward
        float strafeInput = Input.GetAxis("Horizontal");       // A/D for strafing left/right
        float liftInput = (Input.GetKey(KeyCode.Space) ? 1 : 0) - (Input.GetKey(KeyCode.LeftShift) ? 1 : 0); // Space/Shift for up/down

        // Apply directional movement based on inputs
        Vector3 moveDirection = transform.forward * forwardInput + transform.right * strafeInput + transform.up * liftInput;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Input for pitch, yaw, and roll using arrow keys and Q/E for roll
        float pitchInput = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0); // Up/Down Arrow for pitch
        float yawInput = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0); // Left/Right Arrow for yaw
        float rollInput = (Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0);                 // Q/E for roll

        // Apply rotations for pitch, yaw, and roll based on inputs
        transform.Rotate(Vector3.right, pitchInput * rotationSpeed * Time.deltaTime);         // Pitch
        transform.Rotate(Vector3.up, yawInput * rotationSpeed * Time.deltaTime);              // Yaw
        transform.Rotate(Vector3.forward, -rollInput * rotationSpeed * Time.deltaTime);       // Roll
    }
}
*/
