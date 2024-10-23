using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CameraArmProperties
{
    public Transform target;
    [Min(0)] public float smoothing;
    public Vector3 posOffset;
    public Vector2 posOffsetScale;
    [Min(1f)] public float zoomSpeed;
    [HideInInspector] public float zoomFactor;

    // Initializes struct fields with default values, struct fields initializers are availaible for version 10.0 of C# or greater, current is 9.O
    public void InitAsDefault()
    {
        smoothing = 10f;
        posOffset = new Vector3(0f, 13f, -7f);
        posOffsetScale = new Vector2(0.5f, 2f);
        zoomSpeed = 20f;
        zoomFactor = 1f;
    }

    // Update the Zoom of the camera depending on the mouse wheel
    public void OnZoomChange()
    {
        zoomFactor -= Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed;
        zoomFactor = Mathf.Clamp(zoomFactor, posOffsetScale.x, posOffsetScale.y);
    }
}

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraArmProperties m_CameraArmProperties;
    private Vector3 m_CurrentVelocity;

    void Start()
    {
        //m_CameraArmProperties.InitAsDefault();

        if (m_CameraArmProperties.target == null)
            return;
        transform.position = m_CameraArmProperties.target.position + m_CameraArmProperties.posOffset;
        transform.LookAt(m_CameraArmProperties.target);
    }

    private void Update()
    {
        m_CameraArmProperties.OnZoomChange();

        if (m_CameraArmProperties.target == null)
            return;

        Vector3 targetCamPos = m_CameraArmProperties.target.position + m_CameraArmProperties.posOffset * m_CameraArmProperties.zoomFactor;
        transform.position = targetCamPos;// Vector3.SmoothDamp(transform.position, targetCamPos, ref m_CurrentVelocity, m_CameraArmProperties.smoothing);
    }
}
