using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_SquadAgent_LeaderIsShooting", menuName = "FSM/Decisions/SquadAgent/LeaderIsShooting", order = 0)]
public class FSMDecision_SquadAgent_LeaderIsShooting : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        return squadAgent.squadController.leader.isShooting;
    }
}