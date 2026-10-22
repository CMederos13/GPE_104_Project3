using UnityEngine;

public class StarShipPawn : Pawn
{
    private Transform tf;
    private Rigidbody rb;
    private Shooter sh;


    [Header("Movement")]
    public float thrustForce = 20f; // W/S push strength (Physical force)
    public float yawSpeed = 90f; // A/D turn speed in degrees per second 
    public float pitchSpeed = 90f;// Z/X nose up/down speed in degrees per second 
    public float rollSpeed = 120f; // Q/E roll speed in degrees per second

    private void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        sh = GetComponent<Shooter>();
    }

    //pushes the ship along its forward axis with physics 
    public override void Thrust(float direction)
    {
        if (rb != null)
        {
            rb.AddForce(tf.forward * direction * thrustForce);
        }
    }

    //Turns around the up axis, Time.deltaTime makes it degree per second instead of per frame 
    public override void Yaw(float direction)
    {
        tf.Rotate(0, direction * yawSpeed * Time.deltaTime, 0);
    }

    // Tilts the nose around the right axis 
    public override void Pitch(float direction)
    {
        tf.Rotate(direction * pitchSpeed * Time.deltaTime, 0, 0);
    }

    // Rolls around the forward axis
    public override void Roll(float direction)
    {
        tf.Rotate(0, 0, direction * rollSpeed * Time.deltaTime);
    }

    public override void Shoot()
    {
        //telling our shooter component to Fire
        if (sh != null)
        {
            sh.Shoot();
        }
    }
}






