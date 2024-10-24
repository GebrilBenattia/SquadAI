using UnityEngine;

[CreateAssetMenu(fileName = "CircleFormationRule", menuName = "FormationRules/Circle", order = 2)]
public class CircleFormationRule : FormationRule
{
    // ######################################### VARIABLE ########################################

    [Header("Formation Variable")]
    [SerializeField] float Distance = 2.0f;

    // ######################################### FUNCTION ########################################

    public override Vector3 ComputeFormation(Transform _Transform, int _Index, int _AgentNbr)
    {
        float angle = _Index * (2f * Mathf.PI / _AgentNbr);

        return new Vector3(_Transform.position.x + Distance * Mathf.Cos(angle), _Transform.position.y, _Transform.position.z + Distance * Mathf.Sin(angle));
    }
}
