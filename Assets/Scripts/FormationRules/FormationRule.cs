using UnityEngine;

public abstract class FormationRule : ScriptableObject
{
    // ######################################### FUNCTION ########################################

    public abstract Vector3 ComputeFormation(Transform _Transform, int _Index, int _AgentNbr);
}