using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Private Variables
    private float m_Damage = 0f;
    private float m_Speed = 0f;
    private float m_LifeTime = 0f;
    private int m_OwnerTeamIndex;

    // ######################################### FUNCTIONS ########################################

    public void Init(BulletDataSO _BulletData, int _OwnerTeamIndex)
    {
        // Init Variables
        m_Speed = _BulletData.speed;
        m_Damage = _BulletData.damage;
        m_LifeTime = _BulletData.lifeTime;
        m_OwnerTeamIndex = _OwnerTeamIndex;
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
            if (agent.teamIndex != m_OwnerTeamIndex) {
                agent.AddDamage(m_Damage);
                Destroy(gameObject);
            }
        }
        else if (!_Other.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }
}
