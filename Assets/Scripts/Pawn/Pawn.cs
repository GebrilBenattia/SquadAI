using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Pawn : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_Agent = null;
    public NavMeshAgent Agent { get { return m_Agent; } }

    [SerializeField] private Rigidbody m_Rigidbody = null;
    public Rigidbody Rigidbody { get { return m_Rigidbody; } }

    [SerializeField][Min(0f)] private float m_MovementSpeed = 5f;
    public float MovementSpeed { get { return m_MovementSpeed; } }

    public virtual void Move(Vector3 _Direction)
    {
        m_Rigidbody.velocity = _Direction * m_MovementSpeed;
    }

    public virtual void Shoot()
    {
        
    }
}