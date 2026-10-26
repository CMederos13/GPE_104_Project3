using UnityEngine;

// Health pack barrel: heals the player
public class HealthPickup : Pickup
{
    [Header("Healing")]
    public float healAmount = 25f;

    protected override bool Apply(StarShipPawn player)
    {
        Health health = player.GetComponent<Health>();

        // Already at full health (or no Health) = don't use up the pack
        if (health == null || health.currentHealth >= health.maxHealth)
        {
            return false;
        }

        health.Heal(healAmount);
        return true;
    }
}