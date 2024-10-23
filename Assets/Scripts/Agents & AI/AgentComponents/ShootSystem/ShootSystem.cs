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

    // Private Variables
    private float m_MaxCooldown;
    private float m_Cooldown = 0f;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        m_MaxCooldown = 1f / m_FireRate;
    }

    public void Fire()
    {
        // Check for cooldown
        if (m_Cooldown > 0f) return;

        // Update Cooldown then spawn bullet
        m_Cooldown += m_MaxCooldown;
        m_BulletData.Spawn(m_MuzzleSocket.position, m_MuzzleSocket.rotation);
    }

    private void Update()
    {
        // Update cooldown
        if (m_Cooldown > 0f) {
            m_Cooldown -= Time.deltaTime;
        }
    }
}
