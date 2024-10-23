using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_Chase", menuName = "FSM/Actions/Chase", order = 0)]
public class FSMAction_Chase : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) { }

    public override void Stop(FSMBaseStateMachine _StateMachine) 
    {
        NavMeshAgent agent = _StateMachine.GetComponent<NavMeshAgent>();
        agent.SetDestination(_StateMachine.transform.position);
    }

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        NavMeshAgent agent = _StateMachine.GetComponent<NavMeshAgent>();
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        if (sightSensor.isAgentDetected) agent.SetDestination(sightSensor.detectedAgent.transform.position);
    }
}
