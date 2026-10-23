using UnityEngine;

// UFO enemy: turns toward a target and flies forward by changing its position, NOT physics
public class UFOPawn : Pawn
{
    [Header("Seeking")]
    public float moveSpeed = 8f;  // meters per second
    public float turnSpeed = 90f; // degrees per second, lower = wider turns that the player can dodge

    // Turns a little each frame toward the target instead of snapping, so it feels like it's chasing
    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position; // end minus start = direction to the target

        if (direction == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    // Moves by setting position directly 
    public override void MoveForward()
    {
        transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
    }

    // Required by Pawn, UFOs doesn't use these
    public override void Thrust(float direction) { }
    public override void Yaw(float direction) { }
    public override void Pitch(float direction) { }
    public override void Roll(float direction) { }
    public override void Shoot() { }
}