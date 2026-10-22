using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportSprite : MonoBehaviour
{
    public Key TeleportKey = Key.T;

    public Transform tf;
    //Setting the Min and Max Values
    public float minX = -1f;
    public float maxX = 1f;
    public float minY = -1f;
    public float maxY = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // is orginally what I wanted to do at first
        // if (Keyboard.current[].isPressed)
        //instead I'll do it like the video
        if (Keyboard.current[TeleportKey].wasPressedThisFrame)
        {
            tf.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}
