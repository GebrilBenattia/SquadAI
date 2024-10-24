using UnityEngine;

public class Agent : MonoBehaviour, IDamageable
{
    // ######################################### VARIABLES ########################################

    // Agent Settings
    [Header("Agent Settings")]
    [SerializeField] protected float _maxHealth;
    [SerializeField][Min(0)] protected float _rotationSpeed;
    [SerializeField] protected int _teamIndex;

    // Private Variables
    protected bool _isDead;
    protected float _health;

    // ###################################### GETTER / SETTER #####################################

    public int teamIndex => _teamIndex;
    public float maxHealth => _maxHealth;
    public float health => _health;
    public bool isDead => _isDead;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        _health = _maxHealth;
    }

    public virtual void SetLookRotation(Quaternion _Rotation)
    {
        transform.eulerAngles = new Vector3(0, Quaternion.Lerp(transform.rotation, _Rotation, Time.deltaTime * _rotationSpeed).eulerAngles.y, 0);
    }

    public void Heal()
    {
        _health = _maxHealth;
    }

    protected virtual void EventGetDamaged(Agent _DamageCauser)
    {

    }

    public void AddDamage(float _Damage, Agent _DamageCauser)
    {
        if (_isDead)
            return;

        EventGetDamaged(_DamageCauser);

        _health -= _Damage;
        if (_health <= 0) _isDead = true;
    }
}
