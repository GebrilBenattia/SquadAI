using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_SquadAgent_HealLeader", menuName = "FSM/Actions/SquadAgent/HealLeader", order = 0)]
public class FSMAction_SquadAgent_HealLeader : FSMAction
{
    // ######################################### VARIABLES ########################################

    [SerializeField] private float m_HealingTime;

    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) 
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        squadAgent.squadController.canHealLeader = false;
    }

    public override void Stop(FSMBaseStateMachine _StateMachine) 
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        squadAgent.squadController.canHealLeader = true;
        squadAgent.StopHealing();
    }

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        NavMeshAgent navMeshAgent = _StateMachine.GetComponent<NavMeshAgent>();
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();

        navMeshAgent.SetDestination(squadAgent.squadController.leader.transform.position);
        if (!squadAgent.isHealing) {
            float dist = Vector3.Distance(_StateMachine.transform.position, squadAgent.squadController.leader.transform.position);
            if (dist <= navMeshAgent.stoppingDistance) squadAgent.StartHealing(m_HealingTime);
        }
        else if (squadAgent.healingTime <= 0) {
            squadAgent.squadController.leader.Heal();
            squadAgent.squadController.canHealLeader = true;
            squadAgent.StopHealing();
        }
    }
}
