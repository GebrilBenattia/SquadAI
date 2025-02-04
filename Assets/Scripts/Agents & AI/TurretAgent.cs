using UnityEngine;

public class TurretAgent : Agent
{
    // ######################################### VARIABLES ########################################

    // References
    [Header("References")]
    [SerializeField] private Transform m_Rotator;
    [SerializeField] private Transform m_MuzzleSocket;

    // ###################################### GETTER / SETTER #####################################

    public Transform rotator => m_Rotator;
    public Transform fireSocket => m_MuzzleSocket;

    // ######################################### FUNCTIONS ########################################

    public override void SetLookRotation(Quaternion _Rotation)
    {
        m_Rotator.rotation = Quaternion.Lerp(m_Rotator.rotation, _Rotation, Time.deltaTime * _rotationSpeed);
    }

    private void Update()
    {
        if (_isDead) Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(m_MuzzleSocket.position, m_MuzzleSocket.position + m_Rotator.forward * 3f);
    }
#endif
}
