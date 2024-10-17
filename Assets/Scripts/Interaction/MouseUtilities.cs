using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUtilities
{
    public static Vector3 GetMouseWorldPos()
    {
        // Step 1: Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Step 2: Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        // Step 3: Check if the ray hits the ground
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Step 4: Calculate the direction from the player to the hit point
            return hit.point;
        }

        Debug.LogWarning("Couldn't find a mouse world position.");
        return Vector3.zero;
    }
}
