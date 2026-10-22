using UnityEngine;


// Decides what the UFO does; Turns it towards the player and chases them 
public class UFOController : AIController
{
    public override void Start()
    {
        // The UFO's pawn is on the same object as this controller
        pawn = GetComponent<Pawn>();
    }

    public override void Update()
    {
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        FindPlayerTarget();

        // Nothing to chase while the player respawns
        if (pawn == null || target == null)
        {
            return;
        }

        //Vector math is used; to give direction from the UFO to the Player
        Vector3 directionToPlayer = target.position - pawn.transform.position;

        // Face the player; then telling the pawn to move forward
        pawn.transform.up = directionToPlayer;
        pawn.MoveForwardLocal();
    }
}



