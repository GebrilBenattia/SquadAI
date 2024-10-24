using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Private Variables
    private float m_Damage = 0f;
    private float m_Speed = 0f;
    private float m_LifeTime = 0f;
    private Agent m_Owner;

    // ######################################### FUNCTIONS ########################################

    public void Init(BulletDataSO _BulletData, Agent _Owner)
    {
        // Init Variables
        m_Speed = _BulletData.speed;
        m_Damage = _BulletData.damage;
        m_LifeTime = _BulletData.lifeTime;
        m_Owner = _Owner;
    }

    private void Update()
    {
        // Update position
        transform.position += transform.forward * m_Speed * Time.deltaTime;

        // Update life time
        m_LifeTime -= Time.deltaTime;
        if (m_LifeTime <= 0f) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider _Other)
    {
        if (_Other.CompareTag("Agent")) {
            Agent agent = _Other.GetComponent<Agent>();
            if (agent.teamIndex != m_Owner.teamIndex) {
                agent.AddDamage(m_Damage, m_Owner);
                Destroy(gameObject);
            }
        }
        else if (!_Other.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }
}
