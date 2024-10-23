using UnityEngine;

[CreateAssetMenu(fileName = "NewCourseSettings", menuName = "ScriptableObjects/Projectile/DefaultCourseSettings", order = 2)]
public class ProjectileCourseSettings : ScriptableObject
{
    public float lifespan;
    public float damage;
    public float damageRadius;
}