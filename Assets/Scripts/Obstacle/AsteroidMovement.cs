using UnityEngine;

// Moves an asteroid in a random direction at a steady speed 
public class AsteroidMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1.5f; // Designer can set the speed

    private Vector3 moveDirection; // Random direction picked when asteroids spawn in 


    void Start()
    {
        //picks a random X and Y between -1 and 1
        moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

        //Normalize so every asteroid moves at the same speed

        moveDirection = moveDirection.normalized;
    }
    void Update()
    {
        // Move along the direction every frame
        transform.position = transform.position + moveDirection * moveSpeed * Time.deltaTime;
    }

}
