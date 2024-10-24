using UnityEngine;

[System.Serializable]
public struct CameraArmProperties
{
    // ######################################### VARIABLES ########################################

    public Transform target;
    public Vector3 posOffset;
    public Vector2 posOffsetScale;
    [Min(1f)] public float zoomSpeed;
    [HideInInspector] public float zoomFactor;

    // ######################################### FUNCTION ########################################

    // Update the Zoom of the camera depending on the mouse wheel
    public void OnZoomChange()
    {
        zoomFactor -= Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed;
        zoomFactor = Mathf.Clamp(zoomFactor, posOffsetScale.x, posOffsetScale.y);
    }
}

public class CameraController : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    [Header("Camera Properties")]
    [SerializeField] private CameraArmProperties m_CameraArmProperties;

    // Private Variables
    private Vector3 m_CurrentVelocity;

    // ######################################### FUNCTIONS ########################################

    void Start()
    {
        if (m_CameraArmProperties.target == null)
            return;
        transform.position = m_CameraArmProperties.target.position + m_CameraArmProperties.posOffset;
        transform.LookAt(m_CameraArmProperties.target);
    }

    void Update()
    {
        m_CameraArmProperties.OnZoomChange();

        if (m_CameraArmProperties.target == null)
            return;

        Vector3 targetCamPos = m_CameraArmProperties.target.position + m_CameraArmProperties.posOffset * m_CameraArmProperties.zoomFactor;
        transform.position = targetCamPos;
    }
}
