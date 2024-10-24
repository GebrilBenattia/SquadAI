using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_SquadAgent_NeedToHeal", menuName = "FSM/Decisions/SquadAgent/NeedToHeal", order = 0)]
public class FSMDecision_SquadAgent_NeedToHeal : FSMDecision
{
    // ######################################### VARIABLES ########################################

    [SerializeField] private float m_HealTreshold;

    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        return squadAgent.squadController.canHealLeader && squadAgent.squadController.leader.health <= m_HealTreshold;
    }
}
