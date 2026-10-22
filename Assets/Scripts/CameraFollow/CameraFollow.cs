using UnityEngine;

// Smoothly follows a target (Player's ship) from behind and looks a set distance in front of it 
public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // the ship camera follows 
    [Header("Offset")]
    public Vector3 offsetDirection = new Vector3(0, 0.3f, -1); // which way from the ship the camera sits behind
    public float offsetDistance = 10f; // How far from the ship the camera sits
    public float minDistance = 5f; // Closest the camera can zoom in
    public float maxDistance = 25f; // Farthest the camera can zoom out

    [Header("Zoom Controls")]
    public KeyCode zoomInKey = KeyCode.O;  // [O] moves the camera closer
    public KeyCode zoomOutKey = KeyCode.L; // [L] moves the camera farther away
    public float zoomSpeed = 10f; // How fast the distance changes, in meters per second

    [Header("Smoothing")]
    public float followSpeed = 5f; // Higher = camera catches up faster, lower = smoother and lazier

    [Header("Look Ahead")]
    public float lookAheadDistance = 20f; // How far in front of the ship the camera aims

    // Reads the zoom keys once per frame
    private void Update()
    {
        if (Input.GetKey(zoomInKey))
        {
            offsetDistance = offsetDistance - zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(zoomOutKey))
        {
            offsetDistance = offsetDistance + zoomSpeed * Time.deltaTime;
        }

        // Keeps the distance inside the designer's limits
        offsetDistance = Mathf.Clamp(offsetDistance, minDistance, maxDistance);
    }

    // LateUpdate runs after the ship has moved this frame, so the camera follows where the ship actually is
    private void LateUpdate()
    {
        // Nothing to follow while the ship is dead or not spawned yet
        if (target == null)
        {
            return;
        }

        // Turns the direction from the ship's local space into world space, so the camera stays behind the ship as it turns
        Vector3 desiredPosition = target.position + target.TransformDirection(offsetDirection.normalized) * offsetDistance;

        // Moves part of the way there each frame, which makes the follow smooth
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Aims at a point in front of the ship, using the ship's up so the camera rolls with it
        Vector3 lookPoint = target.position + target.forward * lookAheadDistance;
        transform.LookAt(lookPoint, target.up);
    }
}