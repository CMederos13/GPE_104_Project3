using UnityEngine;

// Astronaut: rescuing one gives points
public class ScorePickup : Pickup
{
    [Header("Score")]
    public int scoreValue = 10;

    protected override void Apply(StarShipPawn player)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.score += scoreValue;
        }
    }
}