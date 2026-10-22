using UnityEngine;

//Wraps this object to the opposite side when it leaves the GameManager's screen bounds
public class ScreenWarp : MonoBehaviour
{

    private void Update()
    {
        Vector3 position = transform.position;
        // Warp edges sit just outside the screen bounds
        float left = GameManager.instance.minX - GameManager.instance.warpMargin;
        float right = GameManager.instance.maxX + GameManager.instance.warpMargin;
        float bottom = GameManager.instance.minY - GameManager.instance.warpMargin;
        float top = GameManager.instance.maxY + GameManager.instance.warpMargin;

        //off the right side? move to the left side (Vice versa)
        if (position.x > right)
        {
            position.x = left;
        }
        else if (position.x < left)
        {
            position.x = right;
        }

        // Off the top? Move to the bottom (Vice Versa)
        if (position.y > top)
        {
            position.y = bottom;
        }
        else if (position.y < bottom)
        {
            position.y = top;
        }

        // Apply the new position
        transform.position = position;

    }
}
