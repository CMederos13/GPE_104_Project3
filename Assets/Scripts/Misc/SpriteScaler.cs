using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteScaler : MonoBehaviour
{
    public Key growKey;
    public Key shrinkKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[growKey].wasPressedThisFrame)
        {
            // the more effiecent way of coding this 
            transform.localScale += new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));



            //Increasing the Scale of the Sprite; Examples of how this code could be written.
            // Transform tf;
            // tf = transform;
            // tf.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));

        }
        if (Keyboard.current[shrinkKey].wasPressedThisFrame)
        {

            //Decreasing the scale of the Sprite
            transform.localScale -= new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));

            // essentially could be done this way: gameobject.GetComponent<Transform>()
        }
    }
}
