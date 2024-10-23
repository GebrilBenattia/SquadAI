using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_SquadAgent_Cover", menuName = "FSM/Actions/SquadAgent/Cover", order = 0)]
public class FSMAction_SquadAgent_Cover : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) 
    {
        NavMeshAgent agent = _StateMachine.GetComponent<NavMeshAgent>();
        agent.SetDestination(_StateMachine.transform.position);
    }

    public override void Stop(FSMBaseStateMachine _StateMachine) {}

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        Vector3 dir = squadAgent.squadController.coverPoint - squadAgent.transform.position;
        squadAgent.SetLookRotation(Quaternion.LookRotation(dir.normalized, Vector3.up));

        ShootSystem shootSystem = _StateMachine.GetComponent<ShootSystem>();
        shootSystem.Fire();
    }
}
