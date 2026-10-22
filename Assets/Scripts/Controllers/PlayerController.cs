using UnityEngine;

// Reads the player's key presses and tells the ship (pawn) what to do
public class PlayerController : Controller
{

    [Header("Thrust (Physics)")]
    public KeyCode thrustForwardKey = KeyCode.W; // [W] Pushes the ship forward
    public KeyCode thrustBackwardKey = KeyCode.S;// [S] Pushes the ship backward 

    [Header("Yaw (Turn Left/Right)")]
    public KeyCode yawLeftKey = KeyCode.A; // [A] turns left
    public KeyCode yawRightKey = KeyCode.D; // [D] turns Right 

    [Header("Pitch (Nose Up/Down)")]
    public KeyCode pitchUpKey = KeyCode.Z;   // [Z] tilts the nose up
    public KeyCode pitchDownKey = KeyCode.X; // [X] tilts the nose down

    [Header("Roll")]
    public KeyCode rollLeftKey = KeyCode.Q;  // [Q] rolls left
    public KeyCode rollRightKey = KeyCode.E; // [E] rolls right


    [Header("Combat")]
    // Shoot Mechanics 
    public KeyCode shootKey;


    public override void MakeDecisions()
    {
        if (pawn != null)
        {
            if (Input.GetKey(thrustForwardKey))
            {
                pawn.Thrust(1);
            }
            if (Input.GetKey(thrustBackwardKey))
            {
                pawn.Thrust(-1);
            }
            if (Input.GetKey(yawLeftKey))
            {
                pawn.Yaw(-1);
            }
            if (Input.GetKey(yawRightKey))
            {
                pawn.Yaw(1);
            }
            if (Input.GetKey(pitchUpKey))
            {
                pawn.Pitch(-1);
            }
            if (Input.GetKey(pitchDownKey))
            {
                pawn.Pitch(1);
            }
            if (Input.GetKey(rollLeftKey))
            {
                pawn.Roll(1);
            }
            if (Input.GetKey(rollRightKey))
            {
                pawn.Roll(-1);
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