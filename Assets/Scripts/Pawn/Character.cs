using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Pawn, IDamageable
{
    [SerializeField][Min(0f)] private float m_Health = 100;
    public float Health { get { return m_Health; } }

    private bool m_IsDead;
    public bool IsDead { get { return m_IsDead; } }

    [SerializeField][Min(0f)] private float m_MovementSpeed = 5f;
    public float MovementSpeed { get { return m_MovementSpeed; } }

    public Vector3 targetPoint;

    void Start()
    {
        m_IsDead = false;
    }

    public virtual void Move(Vector3 _Direction)
    {
        Rigidbody.velocity = _Direction * m_MovementSpeed * Time.deltaTime;
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

    public void AddDamage(float _Damage)
    {
        if (m_IsDead) 
            return;

        if (m_Health > 0)
            m_Health -= _Damage;

        else   
            m_IsDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
