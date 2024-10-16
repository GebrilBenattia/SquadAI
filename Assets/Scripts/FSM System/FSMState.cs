using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMState", menuName = "FSM/State")]
public sealed class FSMState : FSMBaseState
{
    // ######################################### VARIABLES ########################################

    // State Settings
    [Header("State Settings")]
    public List<FSMAction> actions = new List<FSMAction>();
    public List<FSMTransition> transitions = new List<FSMTransition>();

    // ######################################### FUNCTIONS ########################################

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        for (int i = 0; i < actions.Count; i++) actions[i].Execute(_StateMachine);
        for (int i = 0; i < transitions.Count; i++) transitions[i].Execute(_StateMachine);
    }
}
