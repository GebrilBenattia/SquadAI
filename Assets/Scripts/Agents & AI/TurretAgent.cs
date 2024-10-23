using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAgent : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // References
    [Header("References")]
    [SerializeField] private Transform m_Rotator;
    [SerializeField] private Transform m_MuzzleSocket;

    // Turret Settings
    [Header("Turret Settings")]
    [SerializeField][Min(0)] private float m_RotationSpeed;

    // ###################################### GETTER / SETTER #####################################

    public Transform rotator
    { get { return m_Rotator; } }
    public Transform fireSocket
    { get { return m_MuzzleSocket; } }

    // ######################################### FUNCTIONS ########################################

    public void SetTargetRotation(Quaternion _Rotation)
    {
        m_Rotator.rotation = Quaternion.Lerp(m_Rotator.rotation, _Rotation, Time.deltaTime * m_RotationSpeed);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(m_MuzzleSocket.position, m_MuzzleSocket.position + m_Rotator.forward * 3f);
    }
#endif
}
