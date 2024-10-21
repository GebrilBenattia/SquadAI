using UnityEngine;

public abstract class LaunchVelocityPattern : ScriptableObject
{
    [SerializeField] private float m_LaunchForce;
    public float LaunchForce { get { return m_LaunchForce; } }

    public abstract Vector3 ComputeLaunchVelocity(Transform _Owner);
}