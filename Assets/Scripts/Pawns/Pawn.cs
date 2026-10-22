using UnityEngine;

// Base class for anything a controller can move (Player Ship, UFO)
public abstract class Pawn : MonoBehaviour
{
    
    public abstract void Thrust(float direction);// Moves forward or backward along the pawn's foward axis 
    public abstract void Yaw(float direction);// Turns Left or right around pawn's up axis
    public abstract void Pitch(float direction);//Tilts the nose down or up around the pawn's right axis
    public abstract void Roll(float direction);//Rolls left or right around the pawn's forward axis 

    //Fires the pawn's weapon 
    public abstract void Shoot(); 
   
      
}

