using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_InLineOfSight", menuName = "FSM/Decisions/InLineOfSight", order = 0)]
public class FSMDecision_InLineOfSight : FSMDecision
{
    // ######################################### VARIABLES ########################################

    // InLineOfSight Decision Settings
    [Header("InLineOfSight Decision Settings")]
    [SerializeField] private bool m_CheckIsInLine;

    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        return sightSensor.isObjectDetected == m_CheckIsInLine;
    }
}
