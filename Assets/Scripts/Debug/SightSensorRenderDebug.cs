using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightSensorRenderDebug : MonoBehaviour
{
    // ######################################### SINGLETON ########################################

    private static SightSensorRenderDebug m_Instance;
    public static SightSensorRenderDebug instance
    { get { return m_Instance; } }

    // ######################################### VARIABLES ########################################

    // References
    [Header("References")]
    [SerializeField] private Toggle m_Toggle;

    // Sight Sensor Render Settings
    [Header("Sight Sensor Render Settings")]
    [SerializeField] private bool m_EnableRenderGizmos;
    [SerializeField] private bool m_EnableDebug;
    public Material lineMaterial;
    [SerializeField] private Color m_MaxSightRadiusColor;
    [SerializeField] private Color m_MinSightRadiusColor;
    [SerializeField] private Color m_SightAngleColor;
    [SerializeField] private Color m_TriggeredMaxSightRadiusColor;
    [SerializeField] private Color m_TriggeredMinSightRadiusColor;
    [SerializeField] private Color m_TriggeredSightAngleColor;
    [SerializeField] private Color m_LineToTargetColor;

    // ###################################### GETTER / SETTER #####################################

    public bool enableRenderGizmos => m_EnableRenderGizmos;
    public bool enableDebug => m_EnableDebug;
    public Color maxSightRadiusColor => m_MaxSightRadiusColor;
    public Color minSightRadiusColor => m_MinSightRadiusColor;
    public Color sightAngleColor => m_SightAngleColor;
    public Color triggeredMaxSightRadiusColor => m_TriggeredMaxSightRadiusColor;
    public Color triggeredMinSightRadiusColor => m_TriggeredMinSightRadiusColor;
    public Color triggeredSightAngleColor => m_TriggeredSightAngleColor;
    public Color lineToTargetColor => m_LineToTargetColor;

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
