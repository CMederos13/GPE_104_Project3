using UnityEngine;

// Reads the player's key presses and tells the ship (pawn) what to do
public class PlayerController : Controller
{
    [Header("Teleport Controls")]
    // [T] key for random teleport 
    public KeyCode TeleportKey;

    [Header("Local Movement (Ship-Facing)")]
    //[W] Key For moving Forward 
    public KeyCode MoveForwardLocal;
    //[S] key For moving Backward
    public KeyCode MoveBackwardLocal;
    //[D] Key For Rotating Clockwise 
    public KeyCode RotateClockwise;
    //[A] Key For Rotating Counter-Clockwise
    public KeyCode RotateCounterClock;

   
    [Header("World Movement (Arrow Keys)")]
    //World Space Movement 
    //[Up] Arrow
    public KeyCode MoveForwardWorld;
    //[Down] Arrow
    public KeyCode MoveBackwardWorld;
    //[Left] Arrow
    public KeyCode MoveLeftWorld;
    //[Right] Arrow
    public KeyCode MoveRightWorld;

    [Header("Turbo Speed")]
    //Speed Change
    //Left Shift Button
    public KeyCode TurboSpeedL;
    
    //Right Shift Button
    public KeyCode TurboSpeedR;
   
    [Header("Combat")]
    // Shoot Mechanics 
    public KeyCode shootKey;


    public override void MakeDecisions()
    {
        if (pawn != null)
        {
            if (Input.GetKey(TurboSpeedL) || Input.GetKey(TurboSpeedR))
            {
                // Turbo versions of the method used here  

                if (Input.GetKey(MoveForwardLocal))
                {
                    //Forward
                    pawn.MoveForwardLocalTurbo();
                }
                if (Input.GetKey(MoveBackwardLocal))
                {
                    // Backward
                    pawn.MoveBackwardLocalTurbo();
                }
                if (Input.GetKey(RotateCounterClock))
                {
                    //Counter-clockwise
                    pawn.RotateCounterClockTurbo();
                }
                if (Input.GetKey(RotateClockwise))
                {
                    //Clockwise
                    pawn.RotateClockTurbo();
                }
            }

            else
            {
                //Normal Version method used here
                if (Input.GetKey(MoveForwardLocal))
                {
                    //Forward
                    pawn.MoveForwardLocal();
                }
                if (Input.GetKey(MoveBackwardLocal))
                {
                    //Backward
                    pawn.MoveBackwardLocal();
                }
                if (Input.GetKey(RotateClockwise))
                {
                    //Clockwise
                    pawn.RotateClockwise();
                }
                if (Input.GetKey(RotateCounterClock))
                {
                    //CounterClockwise
                    pawn.RotateCounterClock();

                }

            }


            //World Space Key Presses 

            if (Input.GetKeyDown(MoveForwardWorld))
            {
                // Up 
                pawn.MoveForwardWorld();
            }
            if (Input.GetKeyDown(MoveBackwardWorld))
            {
                // Down
                pawn.MoveBackwardWorld();
            }
            if (Input.GetKeyDown(MoveRightWorld))
            {
                // Right
                pawn.MoveRightWorld();
            }
            if (Input.GetKeyDown(MoveLeftWorld))
            {
                // Left
                pawn.MoveLeftWorld();
            }

            //Teleport Key Pressed
            if (Input.GetKeyDown(TeleportKey))
            {
                pawn.Teleport();
            }

            //Shoot key press 
            if (Input.GetKeyDown(shootKey))
            {
                //telling pawn to shoot
                pawn.Shoot();
            }
        }
    }
       
    //Registers this controller with the GameManager so it's able to hand controls to the new ship
    public override void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.playerController = this;
        }
    }
    
    // Checks for key presses every frame
    public override void Update()
    {
        MakeDecisions();
    }

   
}
