using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootSystemRenderDebug : MonoBehaviour
{
    // ######################################### SINGLETON ########################################

    private static ShootSystemRenderDebug m_Instance;
    public static ShootSystemRenderDebug instance
    { get { return m_Instance; } }

    // ######################################### VARIABLES ########################################

    // References
    [Header("References")]
    [SerializeField] private Toggle m_Toggle;

    // Shoot System Render Settings
    [Header("Shoot System Render Settings")]
    [SerializeField] private bool m_EnableRenderGizmos;
    [SerializeField] private bool m_EnableDebug;
    public Material lineMaterial;
    [SerializeField] private Color m_ShootRadiusColor;

    // ###################################### GETTER / SETTER #####################################

    public bool enableRenderGizmos => m_EnableRenderGizmos;
    public bool enableDebug => m_EnableDebug;
    public Color shootRadiusColor => m_ShootRadiusColor;

    // ######################################### FUNCTIONS ########################################

    public void ToggleDebug()
    {
        m_EnableDebug = m_Toggle.isOn;
    }

    private void Awake()
    {
        m_Instance = this;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        m_Instance = this;
    }
#endif
}
