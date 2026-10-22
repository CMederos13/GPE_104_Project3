using UnityEngine;

// Handles the player's ship dying; explosion sound, camera takes over
public class DeathPawn : Death
{
    public override void Die()
    {
        // Only talks to the GameManager if one exists in the scene
        if (GameManager.instance != null)
        {
            // Play the explosion sound through the GameManager's SFX player
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.deathSound);

            //Hands over Listening priority to the camera so sounds can still be heard after destroyed
            if (GameManager.instance.cameraListener != null)
            {
                GameManager.instance.cameraListener.enabled = true;
            }
        }

        AudioListener shipListener = GetComponent<AudioListener>();

        if (shipListener != null)
        {
            shipListener.enabled = false;
        }

        //Destroying the ship lets the GameManager see it's gone and respawn or end the game
        Destroy(gameObject);
    }

    public override void Start()
    {

    }

    public override void Update()
    {

    }
}