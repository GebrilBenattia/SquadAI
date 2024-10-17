using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_Lifespan = 2f;
    [SerializeField] private int m_Damage = 1;
    [SerializeField] private float m_Power = 100f;

    void Start()
    {
        Destroy(gameObject, m_Lifespan);
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damagedAgent = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damagedAgent == null)
            damagedAgent = collision.gameObject.GetComponent<IDamageable>();
        damagedAgent?.AddDamage(m_Damage);

        Destroy(gameObject);
    }
}