using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemySightSensor : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Sight Sensor Settings
    [Header("Sight Sensor Settings")]
    [SerializeField] private LayerMask m_DetectionLayerMask;
    [SerializeField] private float m_DetectionRadius;
    [SerializeField] private float m_DetectionAngle;

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
        var colliders = Physics.OverlapSphere(transform.position, m_DetectionRadius, m_DetectionLayerMask);

        for (int i = 0; i < colliders.Length; i++) {
            Vector3 dir = colliders[i].transform.position - transform.position;
            if (Vector3.Angle(dir, transform.forward) <= m_DetectionAngle) {
                m_DetectedObject = colliders[i].transform;
                Debug.Log("DETECTION");
            }
        }

        if (colliders.Length == 0) {
            m_DetectedObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_DetectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(m_DetectionAngle / 2f, Vector3.up) * transform.forward * m_DetectionRadius);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(-m_DetectionAngle / 2f, Vector3.up) * transform.forward * m_DetectionRadius);
    }
}
