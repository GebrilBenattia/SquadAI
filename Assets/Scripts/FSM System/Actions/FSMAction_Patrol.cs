using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New FSMAction_Patrol", menuName = "FSM/Actions/Patrol", order = 0)]
public class FSMAction_Patrol : FSMAction
{
    // ######################################### VARIABLES ########################################

    // Patrol Settings
    [Header("Patrol Settings")]
    [SerializeField] private float m_PatrolRadius;

    // ######################################### FUNCTIONS ########################################

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        // Get navMeshAgent
        NavMeshAgent agent = _StateMachine.GetComponent<NavMeshAgent>();

        // Check if the agent reach the point
        if (agent.remainingDistance <= agent.stoppingDistance) {

            // Choose a new random point
            Vector3 randomPoint = _StateMachine.transform.position + Random.insideUnitSphere * m_PatrolRadius;

            // Get the nearest navMesh point from the random point and set destination
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas)) {
                agent.SetDestination(hit.position);
            }
        }
    }
}
