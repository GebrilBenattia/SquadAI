using UnityEngine;

public class SightSensor : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Sight Sensor Settings
    [Header("Sight Sensor Settings")]
    [SerializeField] private LayerMask m_SightLayerMask;
    [SerializeField][Min(0)] private float m_SightMaxRadius;
    [SerializeField][Min(0)] private float m_SightMinRadius;
    [SerializeField][Range(0, 360)] private float m_SightAngle;

    // Private Variables
    private Transform m_DetectedAgent;
    private Agent m_Agent;

    // ###################################### GETTER / SETTER #####################################

    public Transform detectedAgent => m_DetectedAgent;
    public bool isAgentDetected => m_DetectedAgent != null;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        m_Agent = GetComponent<Agent>();
    }

    public bool IsInMaxSightRadius()
    {
        if (!m_DetectedAgent) return false;
        return Vector3.Distance(transform.position, m_DetectedAgent.position) <= m_SightMaxRadius;
    }

    public bool IsInMinSightRadius()
    {
        if (!m_DetectedAgent) return false;
        return Vector3.Distance(transform.position, m_DetectedAgent.position) <= m_SightMinRadius;
    }

    public bool IsInLineOfSight()
    {
        if (!m_DetectedAgent) return false;

        // Get the direction vector from current pos to detected agent
        Vector3 dir = m_DetectedAgent.transform.position - transform.position;

        // Check if the collider is in sight angle
        bool isInAngle = Vector3.Angle(dir, transform.forward) <= m_SightAngle;
        return isInAngle && IsInMinSightRadius();
    }

    private void DetectAgents()
    {
        // OverlapSphere -> Get all colliders in the radius
        var colliders = Physics.OverlapSphere(transform.position, m_SightMinRadius, m_SightLayerMask);
        bool agentIsDetected = false;

        // Loop on each colliders
        for (int i = 0; i < colliders.Length; i++) {

            // Ignore self
            if (colliders[i].gameObject == this.gameObject) continue;

            // Check team index
            Agent agentDetected = colliders[i].GetComponent<Agent>();
            if (m_Agent && agentDetected) {
                if (m_Agent.teamIndex == agentDetected.teamIndex) continue;
            }

            // Get the direction vector from current pos to detected collider
            Vector3 dir = colliders[i].transform.position - transform.position;

            // Check if the collider is in sight angle
            if (Vector3.Angle(dir, transform.forward) <= m_SightAngle) {
                m_DetectedAgent = colliders[i].transform;
                agentIsDetected = true;
            }
        }

        if (!agentIsDetected) {
            m_DetectedAgent = null;
        }
    }

    private void FixedUpdate()
    {
        if (m_DetectedAgent != null && IsInMaxSightRadius()) return;
        DetectAgents();
    }

    private void OnRenderObject()
    {
        if (!SightSensorRenderDebug.instance.enableDebug) return;

        // Render Max Circle
        Color maxCircleColor = isAgentDetected ? SightSensorRenderDebug.instance.triggeredMaxSightRadiusColor : SightSensorRenderDebug.instance.maxSightRadiusColor;
        GLUtils.GLBegin(ref SightSensorRenderDebug.instance.lineMaterial, GL.LINES, maxCircleColor);
        GLUtils.GLRenderCircle(transform.position, m_SightMaxRadius, Quaternion.Euler(90, 0, 0));
        GLUtils.GLEnd();

        // Render Min Circle
        Color minCircleColor = isAgentDetected ? SightSensorRenderDebug.instance.triggeredMinSightRadiusColor : SightSensorRenderDebug.instance.minSightRadiusColor;
        GLUtils.GLBegin(ref SightSensorRenderDebug.instance.lineMaterial, GL.LINES, minCircleColor);
        GLUtils.GLRenderCircle(transform.position, m_SightMinRadius, Quaternion.Euler(90, 0, 0));
        GLUtils.GLEnd();

        // Render sight angle
        Color sightAngleColor = isAgentDetected ? SightSensorRenderDebug.instance.triggeredSightAngleColor : SightSensorRenderDebug.instance.sightAngleColor;
        GLUtils.GLBegin(ref SightSensorRenderDebug.instance.lineMaterial, GL.LINES, sightAngleColor);
        GLUtils.GLRenderLine(transform.position, transform.position + Quaternion.AngleAxis(m_SightAngle / 2f, Vector3.up) * transform.forward * m_SightMinRadius);
        GLUtils.GLRenderLine(transform.position, transform.position + Quaternion.AngleAxis(-m_SightAngle / 2f, Vector3.up) * transform.forward * m_SightMinRadius);
        GLUtils.GLRenderCircle(transform.position, m_SightMinRadius, Quaternion.Euler(90, (-90 + m_SightAngle / 2f) + transform.eulerAngles.y, 0), 100, m_SightAngle);
        GLUtils.GLEnd();

        // Render line between owner and detected object
        if (m_DetectedAgent) {
            GLUtils.GLBegin(ref SightSensorRenderDebug.instance.lineMaterial, GL.LINES, SightSensorRenderDebug.instance.lineToTargetColor);
            GLUtils.GLRenderLine(transform.position, m_DetectedAgent.position);
            GLUtils.GLEnd();
        }
    }

#if UNITY_EDITOR
    private void RenderGizmos()
    {
        // Render Max Circle
        Color maxCircleColor = isAgentDetected ? SightSensorRenderDebug.instance.triggeredMaxSightRadiusColor : SightSensorRenderDebug.instance.maxSightRadiusColor;
        Gizmos.color = maxCircleColor;
        GizmosUtils.RenderCircle(transform.position, m_SightMaxRadius, Quaternion.Euler(90, 0, 0));

        // Render Min Circle
        Color minCircleColor = isAgentDetected ? SightSensorRenderDebug.instance.triggeredMinSightRadiusColor : SightSensorRenderDebug.instance.minSightRadiusColor;
        Gizmos.color = minCircleColor;
        GizmosUtils.RenderCircle(transform.position, m_SightMinRadius, Quaternion.Euler(90, 0, 0));

        // Render sight angle lines
        Color sightAngleColor = isAgentDetected ? SightSensorRenderDebug.instance.triggeredSightAngleColor : SightSensorRenderDebug.instance.sightAngleColor;
        Gizmos.color = sightAngleColor;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(m_SightAngle / 2f, Vector3.up) * transform.forward * m_SightMinRadius);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(-m_SightAngle / 2f, Vector3.up) * transform.forward * m_SightMinRadius);
        GizmosUtils.RenderCircle(transform.position, m_SightMinRadius, Quaternion.Euler(90, (-90 + m_SightAngle / 2f) + transform.eulerAngles.y, 0), 100, m_SightAngle);

        // Render line between owner and detected object
        if (m_DetectedAgent)
        {
            Gizmos.color = SightSensorRenderDebug.instance.lineToTargetColor;
            Gizmos.DrawLine(transform.position, m_DetectedAgent.position);
        }
    }

    private void OnValidate()
    {
        if (m_SightMaxRadius < m_SightMinRadius) m_SightMaxRadius = m_SightMinRadius;
    }

    private void OnDrawGizmosSelected()
    {
        if (!SightSensorRenderDebug.instance.enableRenderGizmos) RenderGizmos();
    }

    private void OnDrawGizmos()
    {
        if (SightSensorRenderDebug.instance.enableRenderGizmos) RenderGizmos();
    }
#endif
}
