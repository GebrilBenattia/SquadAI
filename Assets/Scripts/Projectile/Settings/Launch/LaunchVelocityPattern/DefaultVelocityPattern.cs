using UnityEngine;

[CreateAssetMenu(fileName = "NewLaunchPattern", menuName = "ScriptableObjects/Projectile/LaunchSettings/DefaultLaunchPattern", order = 1)]
public class DefaultVelocityPattern : LaunchVelocityPattern
{
    public override Vector3 ComputeLaunchVelocity(Transform _Owner)
    {
        return _Owner.forward.normalized * LaunchForce;
    }
}