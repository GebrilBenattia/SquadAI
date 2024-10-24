using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // References
    [Header("References")]
    [SerializeField] private Transform m_MuzzleSocket;

    // Shoot Settings
    [Header("Shoot Settings")]
    [SerializeField] private BulletDataSO m_BulletData;
    [SerializeField] private float m_FireRate;
    [SerializeField] private float m_ShootRadius;

    // Private Variables
    private float m_MaxCooldown;
    private float m_Cooldown = 0f;
    private Agent m_Agent;

    // ###################################### GETTER / SETTER #####################################

    public float shootRadius => m_ShootRadius;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        m_MaxCooldown = 1f / m_FireRate;
        m_Agent = GetComponent<Agent>();
    }

    public void Fire()
    {
        // Check for cooldown
        if (m_Cooldown > 0f) return;

        // Update Cooldown then spawn bullet
        m_Cooldown += m_MaxCooldown;
        m_BulletData.Spawn(m_MuzzleSocket.position, m_MuzzleSocket.rotation, m_Agent);
    }

    private void Update()
    {
        // Update cooldown
        if (m_Cooldown > 0f) {
            m_Cooldown -= Time.deltaTime;
        }
    }

    private void OnRenderObject()
    {
        if (!ShootSystemRenderDebug.instance.enableDebug) return;

        // Render Max Circle
        GLUtils.GLBegin(ref ShootSystemRenderDebug.instance.lineMaterial, GL.LINES, ShootSystemRenderDebug.instance.shootRadiusColor);
        GLUtils.GLRenderCircle(transform.position, m_ShootRadius, Quaternion.Euler(90, 0, 0));
        GLUtils.GLEnd();
    }

#if UNITY_EDITOR
    private void RenderGizmos()
    {
        // Render Max Circle
        Gizmos.color = ShootSystemRenderDebug.instance.shootRadiusColor;
        GizmosUtils.RenderCircle(transform.position, m_ShootRadius, Quaternion.Euler(90, 0, 0));
    }

    private void OnDrawGizmosSelected()
    {
        if (!ShootSystemRenderDebug.instance.enableRenderGizmos) RenderGizmos();
    }

    private void OnDrawGizmos()
    {
        if (ShootSystemRenderDebug.instance.enableRenderGizmos) RenderGizmos();
    }
#endif
}
