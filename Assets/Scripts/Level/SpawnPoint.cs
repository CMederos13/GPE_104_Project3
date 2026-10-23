using UnityEngine;

// Marks a spot in the level where an entity can spawn; the designer picks what spawns here
public class SpawnPoint : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject entityPrefab; // UFO, health pack, or astronaut prefab

    // sphere in the Scene view so designers can see the spawn points
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}