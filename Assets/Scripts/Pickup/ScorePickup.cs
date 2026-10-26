using UnityEngine;

// Astronaut: rescuing one gives points
public class ScorePickup : Pickup
{
    [Header("Score")]
    public int scoreValue = 10;

    protected override bool Apply(StarShipPawn player)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.score += scoreValue;
        }

        return true; // astronauts are always rescued
    }
}