using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SightSensor : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Sight Sensor Settings
    [Header("Sight Sensor Settings")]
    [SerializeField] private LayerMask m_DetectionLayerMask;
    [SerializeField][Min(0)] private float m_DetectionRadius;
    [SerializeField][Min(0)] private float m_DetectionAngle;

    // Private Variables
    private Transform m_DetectedObject;

    // ###################################### GETTER / SETTER #####################################

    public Transform detectedObject
    {  get { return m_DetectedObject; } }

    public bool isObjectDetected
    { get { return m_DetectedObject != null; } }

    // ######################################### FUNCTIONS ########################################

    private void FixedUpdate()
    {
        // OverlapSphere -> Get all colliders in the radius
        var colliders = Physics.OverlapSphere(transform.position, m_DetectionRadius, m_DetectionLayerMask);

        // Loop on each colliders
        for (int i = 0; i < colliders.Length; i++) {

            // Get the direction vector from current pos to detected collider
            Vector3 dir = colliders[i].transform.position - transform.position;

            // Check if the collider is in sight angle
            if (Vector3.Angle(dir, transform.forward) <= m_DetectionAngle) {
                m_DetectedObject = colliders[i].transform;
            }
        }

        if (colliders.Length == 0) {
            m_DetectedObject = null;
        }
    }

    private void OnRenderObject()
    {
        if (!SightSensorRenderDebug.instance.enableDebug) return;

        // Render Circle
        Color circleColor = isObjectDetected ? SightSensorRenderDebug.instance.circleTriggeredColor : SightSensorRenderDebug.instance.circleColor;
        GLUtils.GLBegin(ref SightSensorRenderDebug.instance.lineMaterial, GL.LINES, circleColor);
        GLUtils.GLRenderCircle(transform.position, m_DetectionRadius, Quaternion.Euler(90, 0, 0));
        GLUtils.GLEnd();

        // Render sight angle
        Color sightAngleColor = isObjectDetected ? SightSensorRenderDebug.instance.sightAngleTriggeredColor : SightSensorRenderDebug.instance.sightAngleColor;
        GLUtils.GLBegin(ref SightSensorRenderDebug.instance.lineMaterial, GL.LINES, sightAngleColor);
        GLUtils.GLRenderLine(transform.position, transform.position + Quaternion.AngleAxis(m_DetectionAngle / 2f, Vector3.up) * transform.forward * m_DetectionRadius);
        GLUtils.GLRenderLine(transform.position, transform.position + Quaternion.AngleAxis(-m_DetectionAngle / 2f, Vector3.up) * transform.forward * m_DetectionRadius);
        GLUtils.GLEnd();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Render Circle
        Color circleColor = isObjectDetected ? SightSensorRenderDebug.instance.circleTriggeredColor : SightSensorRenderDebug.instance.circleColor;
        Gizmos.color = circleColor;
        GizmosUtils.RenderCircle(transform.position, m_DetectionRadius, Quaternion.Euler(90, 0, 0));

        // Render sight angle lines
        Color sightAngleColor = isObjectDetected ? SightSensorRenderDebug.instance.sightAngleTriggeredColor : SightSensorRenderDebug.instance.sightAngleColor;
        Gizmos.color = sightAngleColor;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(m_DetectionAngle / 2f, Vector3.up) * transform.forward * m_DetectionRadius);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(-m_DetectionAngle / 2f, Vector3.up) * transform.forward * m_DetectionRadius);
        GizmosUtils.RenderCircle(transform.position, m_DetectionRadius, Quaternion.Euler(90, (-90 + m_DetectionAngle / 2f), 0), 100, m_DetectionAngle);
    }
#endif
}
