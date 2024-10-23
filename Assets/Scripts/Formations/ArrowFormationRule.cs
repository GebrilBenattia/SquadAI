using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowFormationRule", menuName = "FormationRules/Arrow", order = 1)]
public class ArrowFormationRule : FormationRule
{
    [SerializeField] float Distance = 2.0f;

    public override Vector3 ComputeFormation(Transform _Transform, int _Index, int _AgentNbr)
    {
        //_Index = _Index + 1;

        Vector3 offset = -_Transform.forward;
        offset += (_Index % 2 == 0) ? _Transform.right : -_Transform.right;

        return _Transform.position + (offset * (Distance * (1 + _Index)));
    }
}