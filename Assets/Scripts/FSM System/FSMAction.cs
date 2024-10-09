using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMAction : ScriptableObject
{
    // ######################################### FUNCTIONS ########################################

    public abstract void Execute(FSMBaseStateMachine _StateMachine);
}
