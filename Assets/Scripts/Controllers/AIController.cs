using UnityEngine;

// Base class for computer-controlled pawns, finds the player for them to chase
public abstract class AIController : Controller
{
    protected Transform target; // what this AI is chasing

    // Asks the GameManager for the player's ship; target stays null if the player is dead or not spawned
    protected void FindPlayerTarget()
    {
        target = null;

        if (GameManager.instance != null && GameManager.instance.playerController != null && GameManager.instance.playerController.pawn != null)
        {
            target = GameManager.instance.playerController.pawn.transform;
        }
    }
}