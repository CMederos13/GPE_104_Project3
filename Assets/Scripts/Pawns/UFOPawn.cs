using UnityEngine;

// The UFO's body; knows HOW to move; the UFOController decides WHERE
public class UFOPawn : Pawn
{
    [Header("Seeking")]
    public float seekSpeed = 2f; // Designer sets how fast the UFO chases the player
    public override void MakeDecsisions()
    {
        
    }

    public override void MoveBackwardLocal()
    {
        
    }

    public override void MoveBackwardLocalTurbo()
    {
        
    }

    public override void MoveBackwardWorld()
    {
        
    }

    // Moves Forward along the way it's facing (the controller turns it towards the player)
    public override void MoveForwardLocal()
    {
        transform.position = transform.position + transform.up * seekSpeed * Time.deltaTime;
    }

    public override void MoveForwardLocalTurbo()
    {
        
    }

    public override void MoveForwardWorld()
    {
        
    }

    public override void MoveLeftWorld()
    {
       
    }

    public override void MoveRightWorld()
    {
       
    }

    public override void RotateClockTurbo()
    {
       
    }

    public override void RotateClockwise()
    {
       
    }

    public override void RotateCounterClock()
    {
       
    }

    public override void RotateCounterClockTurbo()
    {
        
    }

    public override void Shoot()
    {
        
    }

    public override void Start()
    {
       
    }

    public override void Teleport()
    {
        
    }

    public override void Update()
    {
        
    }
}
