using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_SquadAgent_FinishedToProtect", menuName = "FSM/Decisions/SquadAgent/FinishedToProtect", order = 0)]
public class FSMDecision_SquadAgent_FinishedToProtect : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        return !squadAgent.isProtecting;
    }
}
