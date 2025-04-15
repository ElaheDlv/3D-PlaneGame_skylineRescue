using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 5f;            // Bird flying speed
    public float distance = 10f;        // Distance the bird travels before turning around
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the bird forward
        if (movingForward)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);

        // Reverse direction when reaching the set distance
        if (Vector3.Distance(startPosition, transform.position) >= distance)
            movingForward = !movingForward;
    }
}

