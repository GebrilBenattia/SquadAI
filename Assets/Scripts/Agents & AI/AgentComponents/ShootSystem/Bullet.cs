using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Private Variables
    private float m_Damage = 0f;
    private float m_Speed = 0f;
    private float m_LifeTime = 0f;

    // ######################################### FUNCTIONS ########################################

    public void Init(BulletDataSO _BulletData)
    {
        // Init Variables
        m_Speed = _BulletData.speed;
        m_Damage = _BulletData.damage;
        m_LifeTime = _BulletData.lifeTime;
    }

    private void Update()
    {
        // Update position
        transform.position += transform.forward * m_Speed * Time.deltaTime;

        // Update life time
        m_LifeTime -= Time.deltaTime;
        if (m_LifeTime <= 0f) Destroy(gameObject);
    }
}
