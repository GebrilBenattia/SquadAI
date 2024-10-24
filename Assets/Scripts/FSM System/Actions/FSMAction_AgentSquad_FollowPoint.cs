using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_AgentSquad_FollowPoint", menuName = "FSM/Actions/SquadAgent/FollowPoint", order = 0)]
public class FSMAction_AgentSquad_FollowPoint : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) {}
    public override void Stop(FSMBaseStateMachine _StateMachine) {}

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        NavMeshAgent agent = _StateMachine.GetComponent<NavMeshAgent>();
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        agent.SetDestination(squadAgent.followPoint);
    }
}
