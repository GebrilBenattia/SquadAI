using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public abstract class Pawn : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_Agent = null;
    public NavMeshAgent Agent { get { return m_Agent; } }

    [SerializeField] private Rigidbody m_Rigidbody = null;
    public Rigidbody Rigidbody { get { return m_Rigidbody; } }
}