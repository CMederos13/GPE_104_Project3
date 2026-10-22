using UnityEngine;

// Base class for anything a controller can move (Player Ship, UFO)
public abstract class Pawn : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();


    //Jumps to a random spot 
    public abstract void Teleport();


    public abstract void MakeDecsisions();

    //Normal Speed Variant Here 
    public abstract void MoveForwardLocal();

    public abstract void MoveBackwardLocal();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClock();

    //Turbo Speed Variant Here
    public abstract void MoveForwardLocalTurbo();

    public abstract void MoveBackwardLocalTurbo();

    public abstract void RotateClockTurbo();

    public abstract void RotateCounterClockTurbo();

    // World Variant
    public abstract void MoveForwardWorld();

    public abstract void MoveBackwardWorld();

    public abstract void MoveLeftWorld();

    public abstract void MoveRightWorld();

    //Fires the pawn's weapon 
    public abstract void Shoot(); 
   
      
}

