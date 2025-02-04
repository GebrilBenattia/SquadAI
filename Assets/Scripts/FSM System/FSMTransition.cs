using UnityEngine;

[CreateAssetMenu(fileName = "New Transition", menuName = "FSM/Transition")]
public sealed class FSMTransition : ScriptableObject
{
    // ######################################### VARIABLES ########################################

    // Transition Settings
    [Header("Transition Settings")]
    public FSMDecision decision;
    public FSMBaseState trueState;
    public FSMBaseState falseState;

    // ######################################### FUNCTIONS ########################################

    public void Execute(FSMBaseStateMachine _StateMachine)
    {
        // Check for true state
        if (decision.Decide(_StateMachine)) {
            if (trueState is FSMRemainInState) return;
            _StateMachine.SetState(trueState);
        }
        // Check for false state
        else if (!(falseState is FSMRemainInState)) {
            _StateMachine.SetState(falseState);
        }
    }
}