using System.Collections.Generic;
using UnityEngine;

// Holds the data for this level, attach to the parent object of the level's meshes
public class LevelData : MonoBehaviour
{
    [Header("Level Size")]
    public Vector3 levelSize = new Vector3(100, 100, 100); // Width, height and length of the play area in meters

    [Header("Height Limit")]
    public float maxHeight = 40f; // Invisible ceiling, stored per level (not in GameManager or player)

    [Header("Spawning")]
    public int entitiesToSpawn = 6; // How many spawn points get used each time the level loads
    public List<SpawnPoint> spawnPoints; // filled automatically in Awake

    private List<GameObject> spawnedEntities = new List<GameObject>(); // remembered so a restart can clear them

    // Finds every SpawnPoint under this level automatically, so designers drop them in
    private void Awake()
    {
        spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
    }

    // Level loaded = spawn the entities
    private void Start()
    {
        SpawnEntities();
    }

    // Refills the level when it's empty and keeps the player under the ceiling
    private void Update()
    {
        //Refill the level when nothing worth points is left (Only health packs or nothing remaining)
        if (spawnedEntities.Count > 0)
        {
            bool scoringLeft = false;
            foreach (GameObject entity in spawnedEntities)
            {
                // still alive and not a health pack = a ufo or astronaut is left
                if (entity != null && entity.GetComponent<HealthPickup>() == null)
                {
                    scoringLeft = true;
                }
            }
            if (!scoringLeft)
            {
                SpawnEntities();
            }
        }
    

        if (GameManager.instance == null || GameManager.instance.playerController == null)
        {
            return;
        }

        Pawn player = GameManager.instance.playerController.pawn;

        if (player == null)
        {
            return;
        }

        if (player.transform.position.y > maxHeight)
        {
            // Same X and Z, Y snapped back to the limit = feels like hitting an invisible ceiling
            Vector3 position = player.transform.position;
            player.transform.position = new Vector3(position.x, maxHeight, position.z);

            // Cancel upward speed so physics doesn't keep pushing into the ceiling
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null && rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            }
        }
    }


    // Clears old entities, then spawns at a random set of spawn points
    public void SpawnEntities()
    {
        // Count down so removing doesn't skip any (same trick as Project 2)
        for (int i = spawnedEntities.Count - 1; i >= 0; i--)
        {
            if (spawnedEntities[i] != null)
            {
                Destroy(spawnedEntities[i]);
            }
        }
        spawnedEntities.Clear();

        // Copy the list so picked points can be removed and never used twice
        List<SpawnPoint> available = new List<SpawnPoint>(spawnPoints);
        int count = Mathf.Min(entitiesToSpawn, available.Count);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, available.Count);
            SpawnPoint point = available[index];
            available.RemoveAt(index);

            if (point.entityPrefab != null)
            {
                GameObject entity = Instantiate(point.entityPrefab, point.transform.position, point.transform.rotation);
                spawnedEntities.Add(entity);
            }
        }
    }

    // Yellow marks play area, red marks the height limit
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, levelSize.y / 2, 0), levelSize);

        // Ceiling is drawn at world Y = maxHeight, the same height the Update check uses
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, maxHeight, transform.position.z), new Vector3(levelSize.x, 0, levelSize.z));
    }
}