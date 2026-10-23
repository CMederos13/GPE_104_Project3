using UnityEngine;

// UFO death: score, explosion sound and particle effect, then removed 
public class DeathEnemy : Death
{
    [Header("Reward")]
    public int scoreValue = 50;

    [Header("Effects")]
    public GameObject explosionPrefab; // particle system spawned where the enemy died 

    public override void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.score += scoreValue;
            GameManager.instance.sfxPlayer.PlayOneShot(GameManager.instance.deathSound);
        }

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    public override void Start() { }
    public override void Update() { }
}