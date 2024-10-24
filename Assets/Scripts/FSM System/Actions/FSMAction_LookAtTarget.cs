using UnityEngine;

[CreateAssetMenu(fileName = "New FSMAction_LookAtTarget", menuName = "FSM/Actions/LookAtTarget", order = 0)]
public class FSMAction_LookAtTarget : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) {}
    public override void Stop(FSMBaseStateMachine _StateMachine) {}

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        Agent agent = _StateMachine.GetComponent<Agent>();
        if (sightSensor.isAgentDetected) {
            Vector3 dir = sightSensor.detectedAgent.transform.position - agent.transform.position;
            agent.SetLookRotation(Quaternion.LookRotation(dir.normalized, Vector3.up));
        }
    }
}
