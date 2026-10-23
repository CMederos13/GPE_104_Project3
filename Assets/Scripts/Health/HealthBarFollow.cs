using UnityEngine;

// Keeps a world-space health bar above its owner and facing the camera
public class HealthBarFollow : MonoBehaviour
{
    public Transform owner;                         // the UFO this bar belongs to
    public Vector3 offset = new Vector3(0, 2f, 0);  // how far above the owner

    // LateUpdate runs after the UFO moved and turned, so the bar doesn't jitter or spin with it
    private void LateUpdate()
    {
        if (owner == null)
        {
            return;
        }

        transform.position = owner.position + offset;

        if (Camera.main != null)
        {
            transform.rotation = Camera.main.transform.rotation; // always faces the player's camera
        }
    }
}