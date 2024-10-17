using System;
using System.Collections.Generic;
using UnityEngine;

public class FSMBaseStateMachine : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Base State Machine Settings
    [Header("Base State Machine Settings")]
    [SerializeField] private FSMBaseState m_InitialState;

    // Public Variables
    [NonSerialized] public FSMBaseState currentState;

    // Private Variables
    private Dictionary<Type, Component> m_CachedComponents;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        SetState(m_InitialState);
        m_CachedComponents = new Dictionary<Type, Component>();
    }
    
    public void SetState(FSMBaseState _State)
    {
        currentState?.Stop(this);
        currentState = _State;
        currentState.Begin(this);
    }

    public new T GetComponent<T>() where T : Component
    {
        // Return cached component
        if (m_CachedComponents.ContainsKey(typeof(T)))
            return m_CachedComponents[typeof(T)] as T;

        // Get Component and return it
        var component = base.GetComponent<T>();
        if (component != null)
            m_CachedComponents.Add(typeof(T), component);
        return component;
    }

    private void Update()
    {
        currentState.Execute(this);
    }
}
