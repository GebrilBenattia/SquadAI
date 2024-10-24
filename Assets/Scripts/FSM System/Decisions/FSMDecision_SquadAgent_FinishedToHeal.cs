using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_SquadAgent_FinishedToHeal", menuName = "FSM/Decisions/SquadAgent/FinishedToHeal", order = 0)]
public class FSMDecision_SquadAgent_FinishedToHeal : FSMDecision
{
    // ######################################### VARIABLES ########################################

    [SerializeField] private float m_HealTreshold;

    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        return squadAgent.squadController.canHealLeader && !squadAgent.isHealing && squadAgent.healingTime <= 0f;
    }
}