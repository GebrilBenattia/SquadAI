using UnityEngine;

[CreateAssetMenu(fileName = "New FSMAction_Turret_LookAtTarget", menuName = "FSM/Actions/Turret/LookAtTarget", order = 0)]
public class FSMAction_Turret_LookAtTarget : FSMAction
{
    // ######################################### FUNCTIONS ########################################

    public override void Begin(FSMBaseStateMachine _StateMachine) {}
    public override void Stop(FSMBaseStateMachine _StateMachine) {}

    public override void Execute(FSMBaseStateMachine _StateMachine)
    {
        TurretAgent turret = _StateMachine.GetComponent<TurretAgent>();
        SightSensor sightSensor = _StateMachine.GetComponent<SightSensor>();
        if (sightSensor.isAgentDetected) {
            Vector3 dir = sightSensor.detectedAgent.transform.position - turret.fireSocket.transform.position;
            turret.SetLookRotation(Quaternion.LookRotation(dir.normalized, Vector3.up));
        }
    }
}
