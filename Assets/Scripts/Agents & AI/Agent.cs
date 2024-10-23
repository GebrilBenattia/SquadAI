using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Agent Settings
    [Header("Agent Settings")]
    [SerializeField] protected float _maxLife;
    [SerializeField][Min(0)] protected float _rotationSpeed;
    [SerializeField] protected int _teamIndex;

    // ###################################### GETTER / SETTER #####################################

    public int teamIndex => _teamIndex;

    // ######################################### FUNCTIONS ########################################

    public virtual void SetLookRotation(Quaternion _Rotation)
    {
        transform.eulerAngles = new Vector3(0, Quaternion.Lerp(transform.rotation, _Rotation, Time.deltaTime * _rotationSpeed).eulerAngles.y, 0);
    }
}
