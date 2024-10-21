using UnityEngine;

[CreateAssetMenu(fileName = "NewLaunchPattern", menuName = "ScriptableObjects/Projectile/LaunchSettings/RocketLaunchPattern", order = 2)]
public class RocketVelocityPattern : LaunchVelocityPattern
{
    public override Vector3 ComputeLaunchVelocity(Transform _Owner)
    {
        return _Owner.forward.normalized * LaunchForce;
    }
}