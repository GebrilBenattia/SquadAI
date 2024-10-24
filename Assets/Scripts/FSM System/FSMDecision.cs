using UnityEngine;

public abstract class FSMDecision : ScriptableObject
{
    // ######################################### FUNCTION ########################################

    public abstract bool Decide(FSMBaseStateMachine _StateMachine);
}