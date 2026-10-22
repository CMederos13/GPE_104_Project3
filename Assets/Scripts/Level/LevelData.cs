using UnityEngine;

// Holds the data for this level, attach to the parent object of the level's meshes
public class LevelData : MonoBehaviour
{
    [Header("Level Size")]
    public Vector3 levelSize = new Vector3(100, 100, 100); // Width, height and length of the play area in meters

    // Draws the level's bounds as a yellow box in the Scene view so designers can see the play area
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, levelSize.y / 2, 0), levelSize);
    }
}
