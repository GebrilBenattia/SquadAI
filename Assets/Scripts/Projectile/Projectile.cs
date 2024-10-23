using UnityEngine;

public enum ProjectileType
{
    DefaultBullet,
    RapidBullet,
    PoisonousBullet,
    BlastRocket
}

// TODO : Add Damage Types
// TODO : Add Buffs and Debuffs using Scriptable Objects 
// TODO : Link the Debuffs with Damage Types and Buffes to Heal Spells
 
public class Projectile : MonoBehaviour //PoisonousBullet, ExplosiveBullet, SmallRapidBullet, BasicBulett
{
    [SerializeField] private ProjectileLaunchSettings m_LaunchProperties;
    public ProjectileLaunchSettings LaunchProperties { get { return m_LaunchProperties; } }

    [SerializeField] private ProjectileCourseSettings m_CourseProperties;
    public ProjectileCourseSettings CourseProperties {  get { return m_CourseProperties; } }

    void Start()
    {
        //m_CourseProperties.InitAsDefault();
        Destroy(gameObject, m_CourseProperties.lifespan);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damagedAgent = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damagedAgent == null)
            damagedAgent = collision.gameObject.GetComponent<IDamageable>();
        damagedAgent?.AddDamage(m_CourseProperties.damage);

        Destroy(gameObject);
    }
}