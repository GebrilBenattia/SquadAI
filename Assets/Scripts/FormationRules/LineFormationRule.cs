using UnityEngine;

[CreateAssetMenu(fileName = "LineFormationRule", menuName = "FormationRules/Line", order = 2)]
public class LineFormationRule : FormationRule
{
    // ######################################### VARIABLE ########################################

    [Header("Formation Variable")]
    [SerializeField] float Distance = 2.0f;

    // ######################################### FUNCTION ########################################
    public override Vector3 ComputeFormation(Transform _Transform, int _Index, int _AgentNbr)
    {
        Vector3 offset = -_Transform.forward;

        return _Transform.position + (offset * (Distance * (1 + _Index)));
    }
}