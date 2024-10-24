using UnityEngine;

[CreateAssetMenu(fileName = "ArrowFormationRule", menuName = "FormationRules/Arrow", order = 1)]
public class ArrowFormationRule : FormationRule
{
    // ######################################### VARIABLE ########################################

    [Header("Formation Variable")]
    [SerializeField] float Distance = 2.0f;

    // ######################################### FUNCTION ########################################

    public override Vector3 ComputeFormation(Transform _Transform, int _Index, int _AgentNbr)
    {
        Vector3 offset = -_Transform.forward;
        offset += (_Index % 2 == 0) ? _Transform.right : -_Transform.right;

        return _Transform.position + (offset * (Distance * (1 + _Index)));
    }
}