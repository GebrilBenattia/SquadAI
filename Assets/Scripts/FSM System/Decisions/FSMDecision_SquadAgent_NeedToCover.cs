using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_SquadAgent_NeedToCover", menuName = "FSM/Decisions/SquadAgent/NeedToCover", order = 0)]
public class FSMDecision_SquadAgent_NeedToCover : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        return squadAgent.squadController.needToCover;
    }
}
