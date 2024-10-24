using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_SquadAgent_ProtectLeader", menuName = "FSM/Actions/SquadAgent/ProtectLeader", order = 0)]
public class FSMAction_SquadAgent_ProtectLeader : FSMAction
{
    // ######################################### VARIABLES ########################################

    [SerializeField] private float m_OffsetDistFromLeader;

    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) 
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        squadAgent.squadController.canProtectLeader = false;
        squadAgent.StartProtecting();
    }
    public override void Stop(FSMBaseStateMachine _StateMachine) 
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        squadAgent.squadController.canProtectLeader = true;
    }

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        SquadAgent squadAgent = _StateMachine.GetComponent<SquadAgent>();
        NavMeshAgent navMeshAgent = _StateMachine.GetComponent<NavMeshAgent>();
        ShootSystem shootSystem = _StateMachine.GetComponent<ShootSystem>();

        if (!squadAgent.squadController.leader.nearestDamageCauser) {
            squadAgent.StopProtecting();
            return;
        }

        // Get Target pos, then move to
        AgentPlayer leader = squadAgent.squadController.leader;
        Vector3 dirForTargetPos = leader.nearestDamageCauser.transform.position - leader.transform.position;
        Vector3 targetPos = leader.transform.position + dirForTargetPos.normalized * m_OffsetDistFromLeader;
        navMeshAgent.SetDestination(targetPos);

        // Update Look rotation
        Vector3 dir = leader.nearestDamageCauser.transform.position - squadAgent.transform.position;
        squadAgent.SetLookRotation(Quaternion.LookRotation(dir.normalized, Vector3.up));

        // Shoot to target
        shootSystem.Fire();
    }
}
