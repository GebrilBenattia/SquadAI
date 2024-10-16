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

    [SerializeField][Min(0f)] private float m_MovementSpeed = 5f;
    public float MovementSpeed { get { return m_MovementSpeed; } }

    public virtual void Move(Vector3 _Direction)
    {
        m_Rigidbody.velocity = _Direction * m_MovementSpeed;
    }

    public virtual void FaceMouse()
    {
        Vector3 mouseWorldPos = MouseUtilities.GetMouseWorldPos();

        Vector3 directionToFace = mouseWorldPos - transform.position;

        // Ensure we only rotate on the Y-axis (no vertical rotation)
        directionToFace.y = 0;

        FaceTarget(directionToFace);
    }

    public virtual void FaceTarget(Vector3 _Target)
    {
        Quaternion targetRotation = Quaternion.LookRotation(_Target);

        // Smooth rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);  
    }

    public virtual void Shoot()
    {
        
    }
}