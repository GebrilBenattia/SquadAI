using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Pawn
{
    [SerializeField] private InputActionReference m_DesiredVelocity;

    private void Awake()
    {

    }

    private void Update()
    {
        FaceMouse();
        Move(m_DesiredVelocity.action.ReadValue<Vector3>());
    }
}