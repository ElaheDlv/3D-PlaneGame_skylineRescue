
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform plane;            // Reference to the plane object
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust as needed to position behind the plane

    void LateUpdate()
    {
        // Directly set the camera position without smoothing
        transform.position = plane.position + offset;

        // Make the camera look slightly downward to see the plane
        transform.LookAt(plane.position + Vector3.up * 2);
    }
}
/*
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    public Transform plane; // Drag your Plane GameObject here in the Inspector
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust the offset to position the camera relative to the plane

    private void LateUpdate()
    {
        if (plane != null)
        {
            // Set the camera position to be relative to the plane's position and rotation
            transform.position = plane.position + offset;

            // Set the camera rotation to match the plane's rotation
            transform.rotation = plane.rotation;
        }
    }
}
*/
