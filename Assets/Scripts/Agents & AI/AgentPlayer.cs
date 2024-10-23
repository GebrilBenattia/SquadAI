using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class AgentPlayer : Agent
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI m_TextPlayerLife;

    // Agent Player Settings
    [Header("Agent Player Settings")]
    [SerializeField] private float m_MoveSpeed;

    // Private Variables
    private ShootSystem m_ShootSystem;
    private Vector3 m_LookAtPos;
    private bool m_IsShooting;

    // Getter / Setter
    public Vector3 lookAtPos => m_LookAtPos;
    public bool isShooting => m_IsShooting;

    private void Awake()
    {
        _health = _maxHealth;
        m_ShootSystem = GetComponent<ShootSystem>();
    }

    private void FaceMouse()
    {
        m_LookAtPos = MouseUtilities.GetMouseWorldPos();
        Vector3 directionToFace = m_LookAtPos - transform.position;

        // Ensure we only rotate on the Y-axis (no vertical rotation)
        directionToFace.y = 0;

        SetLookRotation(Quaternion.LookRotation(directionToFace));
    }

    private void Move(Vector3 _Direction)
    {
        transform.position += _Direction * m_MoveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        // Update text life
        m_TextPlayerLife.text = "Life: " + _health.ToString() + "/" + _maxHealth.ToString();

        FaceMouse();
        Vector3 moveVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Move(moveVelocity.normalized);

        if (Input.GetMouseButton(0)) {
            m_IsShooting = true;
            m_ShootSystem.Fire();
        }
        else {
            m_IsShooting = false;
        }
    }
}