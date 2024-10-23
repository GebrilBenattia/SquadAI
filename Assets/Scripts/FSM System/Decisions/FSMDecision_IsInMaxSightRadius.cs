using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_IsInMaxSightRadius", menuName = "FSM/Decisions/IsInMaxSightRadius", order = 0)]
public class FSMDecision_IsInMaxSightRadius : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        return sightSensor.IsInMaxSightRadius();
    }
}
