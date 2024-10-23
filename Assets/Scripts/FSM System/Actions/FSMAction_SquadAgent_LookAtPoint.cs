using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_SquadAgent_LookAtPoint", menuName = "FSM/Actions/SquadAgent/LookAtPoint", order = 0)]
public class FSMAction_SquadAgent_LookAtPoint : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) {}
    public override void Stop(FSMBaseStateMachine _StateMachine) {}

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        Vector3 dir = squadAgent.lookAtPoint - squadAgent.transform.position;
        squadAgent.SetLookRotation(Quaternion.LookRotation(dir.normalized, Vector3.up));
    }
}
