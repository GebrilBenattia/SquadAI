using UnityEngine;

public abstract class FSMAction : ScriptableObject
{
    // ######################################### FUNCTIONS ########################################

    public abstract void Begin(FSMBaseStateMachine _StateMachine);
    public abstract void Stop(FSMBaseStateMachine _StateMachine);
    public abstract void Execute(FSMBaseStateMachine _StateMachine);
}