using UnityEngine;

// Damages anything with Health it touches (used by bullets, the ground and obstacles)
public class Damage : MonoBehaviour
{
    [Header("Damage")]
    public float damageAmount; // How much health this takes away

    public bool destroySelfOnHit = true; // bullets destroy themselves on hit
    public bool isInstaKill; // If checked , kills instantly no matter the health

    private Health OtherHealthComponent;

    // When a trigger (like a bullet) touches something with health; deal damage
    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }

    // When two solid colliders hit (like the ship and the ground); deal damage
    private void OnCollisionEnter(Collision collision)
    {
        DealDamage(collision.collider);
    }

    // Finds the Health on what was hit and damages it
    private void DealDamage(Collider other)
    {
        OtherHealthComponent = other.GetComponentInParent<Health>();

        if (OtherHealthComponent != null)
        {
            //Insta-kill deals the target's full max health
            if (isInstaKill)
            {
                OtherHealthComponent.TakeDamage(OtherHealthComponent.maxHealth);
            }
            else
            {
                OtherHealthComponent.TakeDamage(damageAmount);
            }

            // Bullets are destroyed on contact, the ground and walls are not
            if (destroySelfOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}