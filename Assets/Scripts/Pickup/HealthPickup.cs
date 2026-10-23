using UnityEngine;

// Health pack barrel: heals the player
public class HealthPickup : Pickup
{
    [Header("Healing")]
    public float healAmount = 25f;

    protected override void Apply(StarShipPawn player)
    {
        Health health = player.GetComponent<Health>();

        if (health != null)
        {
            health.Heal(healAmount);
        }
    }
}
