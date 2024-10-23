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

    // Private Variables
    private Agent m_Leader;
    private List<SquadAgent> m_SquadAgents = new List<SquadAgent>();

    // ######################################### FUNCTIONS ########################################

    private void Awake()
    {
        m_Leader = Instantiate(m_LeaderPrefab, transform.position, Quaternion.identity).GetComponent<Agent>();
        int squadAgentCount = m_AgentCount - 1;
        for (int i = 0; i < squadAgentCount; i++) {
            m_SquadAgents.Add(Instantiate(m_SquadAgentPrefab, GetFollowPoint(i), Quaternion.identity).GetComponent<SquadAgent>());
        }
    }

    private Vector3 GetFollowPoint(int _AgentIndex)
    {
        if (_AgentIndex <= 3) return m_Leader.transform.position - m_Leader.transform.right * 1.5f + _AgentIndex * m_Leader.transform.right - m_Leader.transform.forward;
        return m_SquadAgents[_AgentIndex - 4].transform.position - m_SquadAgents[_AgentIndex - 4].transform.forward;
    }

    private void Update()
    {
        int squadAgentCount = m_AgentCount - 1;
        for (int i = 0; i < squadAgentCount; i++) {
            m_SquadAgents[i].followPoint = GetFollowPoint(i);
        }
    }
}
