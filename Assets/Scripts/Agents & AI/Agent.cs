using System.Collections;
using System.Collections.Generic;
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

    public void AddDamage(float _Damage)
    {
        if (_isDead)
            return;

        if (_health > 0)
            _health -= _Damage;

        else
            _isDead = true;
    }
}
