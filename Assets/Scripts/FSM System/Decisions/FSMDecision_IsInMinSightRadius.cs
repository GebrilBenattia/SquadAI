using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_IsInMinSightRadius", menuName = "FSM/Decisions/IsInMinSightRadius", order = 0)]
public class FSMDecision_IsInMinSightRadius : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        return sightSensor.IsInMinSightRadius();
    }
}
