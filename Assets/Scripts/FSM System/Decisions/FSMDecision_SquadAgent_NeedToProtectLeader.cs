using UnityEngine;

[CreateAssetMenu(fileName = "New FSMDecision_SquadAgent_NeedToProtectLeader", menuName = "FSM/Decisions/SquadAgent/NeedToProtectLeader", order = 0)]
public class FSMDecision_SquadAgent_NeedToProtectLeader : FSMDecision
{
    // ######################################### FUNCTIONS ########################################

    public override bool Decide(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        return squadAgent.squadController.canProtectLeader && squadAgent.squadController.leader.nearestDamageCauser;
    }
}