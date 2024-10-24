using UnityEngine;

public class FSMBaseState : ScriptableObject
{
    // ######################################### FUNCTIONS ########################################

    public virtual void Begin(FSMBaseStateMachine _StateMachine) {}
    public virtual void Stop(FSMBaseStateMachine _StateMachine) {}
    public virtual void Execute(FSMBaseStateMachine _StateMachine) {}
}