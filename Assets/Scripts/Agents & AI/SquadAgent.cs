using System;
using UnityEngine;
using UnityEngine.AI;

public class SquadAgent : Agent
{
    // ######################################### VARIABLES ########################################

    // Public Variables
    [NonSerialized] public Vector3 followPoint;
    [NonSerialized] public Vector3 lookAtPoint;
    [NonSerialized] public AgentSquadController squadController;
    [NonSerialized] public bool isHealing = false;
    [NonSerialized] public bool isProtecting = false;

    // Private Variables
    private NavMeshAgent m_NavMeshAgent;
    private float m_BaseStoppingDistance;
    private float m_HealingTime;

    public float healingTime => m_HealingTime;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        _health = _maxHealth;
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_BaseStoppingDistance = m_NavMeshAgent.stoppingDistance;
    }

    public void Init(AgentSquadController _AgentSquadController)
    {
        squadController = _AgentSquadController;
    }

    public void StartHealing(float _HealingTime)
    {
        isHealing = true;
        m_HealingTime = _HealingTime;
    }

    public void StopHealing()
    {
        isHealing = false;
    }

    public void StartProtecting()
    {
        isProtecting = true;
        m_NavMeshAgent.stoppingDistance = 0.1f;
    }

    public void StopProtecting()
    {
        isProtecting = false;
        m_NavMeshAgent.stoppingDistance = m_BaseStoppingDistance;
    }

    private void Update()
    {
        if (_isDead) {
            if (isHealing) squadController.canHealLeader = true;
            if (isProtecting) squadController.canProtectLeader = true;

            squadController.RemoveAgent(this);
            Destroy(gameObject);
        }
        if (isHealing && m_HealingTime > 0f) m_HealingTime -= Time.deltaTime;
    }
}
