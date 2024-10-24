using UnityEngine;

public class MouseUtilities
{
    // ######################################### FUNCTION ########################################

    // Return the position of the mouse with a ray shot from the camera in world space
    public static Vector3 GetMouseWorldPos(Camera _ViewCamera)
    {
        Ray ray = _ViewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            return hit.point;
        }

        return Vector3.zero;
    }
}