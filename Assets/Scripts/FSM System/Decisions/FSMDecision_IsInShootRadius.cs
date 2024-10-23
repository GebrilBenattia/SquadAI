using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_IsInShootRadius", menuName = "FSM/Decisions/IsInShootRadius", order = 0)]
public class FSMDecision_IsInShootRadius : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        ShootSystem shootSystem = _StateMachine.GetComponent<ShootSystem>();
        if (sightSensor.isAgentDetected) {
            float dist = Vector3.Distance(sightSensor.detectedAgent.transform.position, _StateMachine.transform.position);
            return dist <= shootSystem.shootRadius;
        }
        return false;
    }
}
