using UnityEngine;

public class StarShipPawn : Pawn
{
    [Header("Components")]
    public Transform tf;
    private Shooter sh;
    

    [Header("Local Movement Speed")]
    public float normalSpeed; // W/S speed
    public float normalRotateSpeed; // A/D rotation speed


    [Header("Turbo Speeds (Shift)")]
   
    public float turboSpeed;
    public float turboRotateSpeed; 

    [Header("World Movement (Arrow Keys)")]
    public float worldSpeed = 2f; // how far each arrow key press jumps the ship
    

  
    

    public override void MoveForwardLocal()
    {
        tf.position = tf.position + tf.up * normalSpeed * Time.deltaTime;
    }

    public override void MoveBackwardLocal()
    {
        tf.position = tf.position + tf.up * -normalSpeed * Time.deltaTime;
    }

    public override void RotateClockwise()
    {
        tf.Rotate(0,0,normalRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClock()
    {
        tf.Rotate(0, 0, normalRotateSpeed * Time.deltaTime);
    }
    //World Section: Arrow keys jump ship in a world directions
    public override void MoveForwardWorld()
    {
        tf.position = tf.position + Vector3.up * worldSpeed;
        PlayTeleportSound();
    }

    public override void MoveLeftWorld()
    {
        tf.position = tf.position + -Vector3.right * worldSpeed;
        PlayTeleportSound();
    }

    public override void MoveRightWorld()
    {
        tf.position = tf.position + Vector3.right * worldSpeed;
        PlayTeleportSound();
    }
    public override void MoveBackwardWorld()
    {
        tf.position = tf.position + -Vector3.up * worldSpeed;
        PlayTeleportSound();
    }

    //Turbo Section
    public override void RotateClockTurbo()
    {
        tf.Rotate(0, 0, turboRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClockTurbo()
    {
        tf.Rotate(0, 0, turboRotateSpeed * Time.deltaTime);
    }

    public override void MoveForwardLocalTurbo()
    {
        tf.position = tf.position + tf.up * turboSpeed * Time.deltaTime;
    }

    public override void MoveBackwardLocalTurbo()
    {
        tf.position = tf.position + tf.up * -turboSpeed * Time.deltaTime;
    }



    public override void MakeDecsisions()
    {
        //Controller only does make decisions
    }

    public override void Shoot()
    {
        // telling our shooter component to shoot
        if (sh != null)
        {
            sh.Shoot();
        }

    }

    // Teleports to a random spot inside the gameManager's screen bound 
    public override void Teleport()
    {
        float x = Random.Range(GameManager.instance.minX, GameManager.instance.maxX);
        float y = Random.Range(GameManager.instance.minY, GameManager.instance.maxY);
        tf.position = new Vector3(x,y,0);
        PlayTeleportSound();
    }

    //plays teleport sound through SFX Player
    private void PlayTeleportSound()
    {
        GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.teleportSound);
    }

    
    public override void Start()
    {
        tf = GetComponent<Transform>();
        sh = GetComponent<Shooter>();
    }

    public override void Update()
    {

    }


}