using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FormationRule : ScriptableObject
{
    public abstract Vector3 ComputeFormation(Transform _Transform, int _Index, int _AgentNbr);
}