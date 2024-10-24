using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgentSquadController : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // References
    [Header("References")]
    [SerializeField] private TMP_Dropdown m_DropdownFormationControl;

    // Agent Squad Controller Settings
    [Header("Agent Squad Controller Settings")]
    [SerializeField] private AgentPlayer m_LeaderAgent;
    [SerializeField] private GameObject m_SquadAgentPrefab;
    [SerializeField][Min(1)] private int m_AgentCount;
    [SerializeField] private FormationRule m_CurrentFormationRule;
    [SerializeField] private FormationRule m_CircleFormationRule;
    [SerializeField] private FormationRule m_ArrowFormationRule;
    [SerializeField] private FormationRule m_LineFormationRule;

    // Public Variables
    [NonSerialized] public bool canHealLeader = true;
    [NonSerialized] public bool canProtectLeader = true;

    // Private Variables
    private List<SquadAgent> m_SquadAgents = new List<SquadAgent>();
    private bool m_NeedToCover = false;
    private Vector3 m_CoverPoint;

    // Getter / Setter
    public AgentPlayer leader => m_LeaderAgent;
    public bool needToCover => m_NeedToCover;
    public Vector3 coverPoint => m_CoverPoint;

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        for (int i = 0; i < m_AgentCount; i++) {
            m_SquadAgents.Add(Instantiate(m_SquadAgentPrefab, GetFollowPoint(i), Quaternion.identity).GetComponent<SquadAgent>());
            m_SquadAgents[i].Init(this);
        }
    }

    public void UpdateFormationRule()
    {
        switch (m_DropdownFormationControl.value) {
            case 0: m_CurrentFormationRule = m_CircleFormationRule; break;
            case 1: m_CurrentFormationRule = m_ArrowFormationRule; break;
            case 2: m_CurrentFormationRule = m_LineFormationRule; break;
        }
    }

    public void RemoveAgent(SquadAgent _Agent)
    {
        m_SquadAgents.Remove(_Agent);
        m_AgentCount = m_SquadAgents.Count;
    }

    private Vector3 GetFollowPoint(int _AgentIndex)
    {
        return m_CurrentFormationRule.ComputeFormation(m_LeaderAgent.transform, _AgentIndex, m_AgentCount);
    }

    private void TriggerIsCovering()
    {
        m_NeedToCover = !m_NeedToCover;
        if (m_NeedToCover) m_CoverPoint = m_LeaderAgent.lookAtPos;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            TriggerIsCovering();
        }

        for (int i = 0; i < m_AgentCount; i++) {
            m_SquadAgents[i].followPoint = GetFollowPoint(i);
            m_SquadAgents[i].lookAtPoint = m_LeaderAgent.lookAtPos;
        }
    }
}