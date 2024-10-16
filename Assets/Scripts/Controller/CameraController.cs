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
    [HideInInspector] public float cameraDeZoomFactor;

    public void InitAsDefault()
    {
        smoothing = 10f;
        posOffset = new Vector3(0f, 13f, -7f);
        posOffsetScale = new Vector2(0.5f, 2f);
        zoomSpeed = 20f;
        cameraDeZoomFactor = 1f;
    }
}

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraArmProperties m_CameraArmProperties;

    void Start()
    {
        m_CameraArmProperties.InitAsDefault();

        if (m_CameraArmProperties.target == null)
            return;
        transform.position = m_CameraArmProperties.target.position + m_CameraArmProperties.posOffset;
        transform.LookAt(m_CameraArmProperties.target);
    }

    void OnDezoomChange()
    {
        m_CameraArmProperties.cameraDeZoomFactor -= Input.mouseScrollDelta.y * Time.deltaTime * 20f;
        m_CameraArmProperties.cameraDeZoomFactor = Mathf.Clamp(m_CameraArmProperties.cameraDeZoomFactor, m_CameraArmProperties.posOffsetScale.x, m_CameraArmProperties.posOffsetScale.y);
    }

    private void Update()
    {
        OnDezoomChange();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_CameraArmProperties.target == null)
            return;
        Vector3 targetCamPos = m_CameraArmProperties.target.position + m_CameraArmProperties.posOffset * m_CameraArmProperties.cameraDeZoomFactor;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, m_CameraArmProperties.smoothing * Time.fixedDeltaTime);
    }
}
