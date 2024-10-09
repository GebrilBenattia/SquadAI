using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : ScriptableObject
{
    // ######################################### FUNCTIONS ########################################

    public abstract bool Decide(FSMBaseStateMachine _StateMachine);
}
