using UnityEngine;

// Pushes the bullet forward when it's fired 
public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float fireForce = 50f; // how hard the bullet is pushed

    public float lifetime = 3f; // How long the bullet lasts before being removed

    private Rigidbody rb;

    private Transform tf;

    // Pushes the bullet forward the way the ship's facing, and sets it up to be destroyed
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        tf = GetComponent<Transform>();

        if (rb != null && tf != null)
        {
            // Impulse gives the bullet one instant push, like a gun firing
            rb.AddForce(tf.forward * fireForce, ForceMode.Impulse);
        }
        // Removes the bullet after "lifetime" seconds so missed shots don't pile up 
        Destroy(gameObject, lifetime);
    }
}