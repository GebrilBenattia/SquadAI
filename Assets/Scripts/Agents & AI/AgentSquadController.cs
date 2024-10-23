using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSquadController : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Agent Squad Controller Settings
    [Header("Agent Squad Controller Settings")]
    [SerializeField] private AgentPlayer m_LeaderAgent;
    [SerializeField] private GameObject m_SquadAgentPrefab;
    [SerializeField][Min(1)] private int m_AgentCount;
    [SerializeField] private FormationRule m_FormationRule;

    // Public Variables
    [NonSerialized] public bool canHealPlayer = true;

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

    public void RemoveAgent(SquadAgent _Agent)
    {
        m_SquadAgents.Remove(_Agent);
        m_AgentCount = m_SquadAgents.Count;
    }

    private Vector3 GetFollowPoint(int _AgentIndex)
    {
        return m_FormationRule.ComputeFormation(m_LeaderAgent.transform, _AgentIndex, m_AgentCount);
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