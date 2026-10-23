using UnityEngine;

// AI brain for the UFO: look at the player, move forward, repeat = a chase
public class UFOController : AIController
{
    public override void Start()
    {
        pawn = GetComponent<Pawn>(); // the UFO controls the pawn on its own object
    }

    public override void Update()
    {
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        if (pawn == null)
        {
            return;
        }

        FindPlayerTarget();

        // No player alive = nothing to chase
        if (target == null)
        {
            return;
        }

        pawn.RotateTowards(target.position);
        pawn.MoveForward();
    }
}