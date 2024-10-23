using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    private List<GameObject> m_ProjectileList = new List<GameObject>();
    public List<GameObject> ProjectileList { get { return m_ProjectileList; } }

    public void LauchSingleProjectile(Transform _Owner, ProjectileLaunchSettings _LaunchProperties)
    {
        if (!_LaunchProperties.projectilePrefab) {
            Debug.LogWarning("Can't launch projectile without knowing the prefab, Check if the prefab is set in the ProjectileLaunchProperties");
            return;
        }

        GameObject bullet = Instantiate(_LaunchProperties.projectilePrefab, _Owner.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = _LaunchProperties.launchVelocity.ComputeLaunchVelocity(_Owner);

        m_ProjectileList.Add(bullet);
    }
}