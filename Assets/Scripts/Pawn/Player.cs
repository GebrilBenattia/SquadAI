using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    [SerializeField] private InputActionReference m_DesiredVelocity;

    [SerializeField] private ProjectileLaunchSettings m_LaunchSettings;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {
        FaceMouse();
        Move(m_DesiredVelocity.action.ReadValue<Vector3>());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<FireSystem>().LauchSingleProjectile(gameObject.transform, m_LaunchSettings);
        }
    }
}