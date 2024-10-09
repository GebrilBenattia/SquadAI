using UnityEngine;

public class FSMBaseState : ScriptableObject
{
    // ######################################### FUNCTIONS ########################################

    public virtual void Execute(FSMBaseStateMachine _StateMachine) {}
}
