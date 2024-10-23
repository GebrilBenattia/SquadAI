using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSquadController : MonoBehaviour
{
    // ######################################### VARIABLES ########################################

    // Agent Squad Controller Settings
    [Header("Agent Squad Controller Settings")]
    [SerializeField] private GameObject m_LeaderPrefab;
    [SerializeField] private GameObject m_SquadAgentPrefab;
    [SerializeField][Min(1)] private int m_AgentCount;
    [SerializeField] private FormationRule m_FormationRule;

    // Private Variables
    private GameObject m_Leader;
    private List<SquadAgent> m_SquadAgents = new List<SquadAgent>();

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        m_Leader = m_LeaderPrefab;//= Instantiate(m_LeaderPrefab, transform.position, Quaternion.identity).GetComponent<SquadAgent>();
        int squadAgentCount = m_AgentCount;
        for (int i = 0; i < squadAgentCount; i++) {
            m_SquadAgents.Add(Instantiate(m_SquadAgentPrefab, GetFollowPoint(i), Quaternion.identity).GetComponent<SquadAgent>());
        }
    }

    private Vector3 GetFollowPoint(int _AgentIndex)
    {
        return m_FormationRule.ComputeFormation(m_Leader.transform, _AgentIndex, m_AgentCount);
    }

    private void Update()
    {
        int squadAgentCount = m_AgentCount;
        for (int i = 0; i < m_AgentCount; i++) {
            m_SquadAgents[i].followPoint = GetFollowPoint(i);
        }
    }
}