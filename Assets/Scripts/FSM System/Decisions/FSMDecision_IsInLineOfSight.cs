using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_IsInLineOfSight", menuName = "FSM/Decisions/IsInLineOfSight", order = 0)]
public class FSMDecision_IsInLineOfSight : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        return sightSensor.IsInLineOfSight();
    }
}
