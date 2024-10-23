using System;
using UnityEngine;

public class SquadAgent : Agent
{
    // ######################################### VARIABLES ########################################

    // Public Variables
    [NonSerialized] public Vector3 followPoint;
    [NonSerialized] public Vector3 lookAtPoint;
    [NonSerialized] public AgentSquadController squadController;
    [NonSerialized] public bool isHealing = false;

    // Private Variables
    private float m_HealingTime;

    public float healingTime => m_HealingTime;

    // ######################################### FUNCTIONS ########################################

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

    private void Update()
    {
        if (_isDead) {
            squadController.RemoveAgent(this);
            Destroy(gameObject);
        }
        if (isHealing && m_HealingTime > 0f) m_HealingTime -= Time.deltaTime;
    }
}
