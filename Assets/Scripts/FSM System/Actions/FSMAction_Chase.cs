using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_Chase", menuName = "FSM/Actions/Chase", order = 0)]
public class FSMAction_Chase : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        NavMeshAgent agent = _StateMachine.GetComponent<NavMeshAgent>();
        EnemySightSensor sightSensor = _StateMachine.GetComponent<EnemySightSensor>();
        if (sightSensor.isObjectDetected) agent.SetDestination(sightSensor.detectedObject.transform.position);
    }
}
