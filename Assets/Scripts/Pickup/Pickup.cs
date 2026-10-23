using UnityEngine;

// Base class for anything the player can pick up; children decide WHAT the pickup does
public abstract class Pickup : MonoBehaviour
{
    [Header("Pickup")]
    public AudioClip pickupSound; // designer picks the sound per pickup

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickup touched by: " + other.name);
        
        // This was made so bullets go through pickups; only the ship's body can collect 
        if (other.GetComponent<Bullet>() != null)
        {
            return;
        }

        // Only the player's ship can pick things up (bullets and UFOs are ignored)
        StarShipPawn player = other.GetComponentInParent<StarShipPawn>();

        if (player == null)
        {
            return;
        }

        Apply(player);

        if (pickupSound != null && GameManager.instance != null)
        {
            GameManager.instance.sfxPlayer.PlayOneShot(pickupSound);
        }

        Destroy(gameObject);
    }

    // Each kind of pickup writes its own effect
    protected abstract void Apply(StarShipPawn player);
}