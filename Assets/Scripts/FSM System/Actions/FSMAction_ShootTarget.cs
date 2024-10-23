using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_ShootTarget", menuName = "FSM/Actions/Shoot Target", order = 0)]
public class FSMAction_ShootTarget : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) {}
    public override void Stop(FSMBaseStateMachine _StateMachine) {}

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        ShootSystem shootSystem = _StateMachine.GetComponent<ShootSystem>();
        shootSystem.Fire();
    }
}
