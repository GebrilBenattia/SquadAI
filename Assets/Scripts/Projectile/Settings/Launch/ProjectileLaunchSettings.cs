using UnityEngine;

[CreateAssetMenu(fileName = "NewLaunchSettings", menuName = "ScriptableObjects/Projectile/DefaultLaunchSettings", order = 1)]
public class ProjectileLaunchSettings : ScriptableObject
{
    public ProjectileType type;
    public GameObject projectilePrefab;
    public LaunchVelocityPattern launchVelocity; // TODO : Use Scriptable objects as this field that will compute the velocity and allow more flexibity over projectile customization
}