using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightSensorRenderDebug : MonoBehaviour
{
    // ######################################### SINGLETON ########################################

    private static SightSensorRenderDebug m_Instance;
    public static SightSensorRenderDebug instance
    { get { return m_Instance; } }

    // ######################################### VARIABLES ########################################

    // Sight Sensor Render Settings
    [Header("Sight Sensor Render Settings")]
    [SerializeField] private bool m_EnableDebug;
    public Material lineMaterial;
    [SerializeField] private Color m_CircleColor;
    [SerializeField] private Color m_SightAngleColor;
    [SerializeField] private Color m_CircleTriggeredColor;
    [SerializeField] private Color m_SightAngleTriggeredColor;

    // ###################################### GETTER / SETTER #####################################

    public bool enableDebug
    { get { return m_EnableDebug; } }
    public Color circleColor
    {  get { return m_CircleColor; } }
    public Color sightAngleColor
    { get {  return m_SightAngleColor; } }
    public Color circleTriggeredColor
    { get { return m_CircleTriggeredColor; } }
    public Color sightAngleTriggeredColor
    { get { return m_SightAngleTriggeredColor; } }

    // ######################################### FUNCTIONS ########################################

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
