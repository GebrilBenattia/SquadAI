using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // References
    [Header("References")]
    [SerializeField] private AgentPlayer m_Player;
    [SerializeField] private GameObject m_GameOverGroup;
    private bool isGameOver = false;

    private void Update()
    {
        if (!isGameOver && m_Player.isDead) {
            isGameOver = true;
            m_GameOverGroup.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnRestart()
    {
        Debug.Log("Reload Scene");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnQuit()
    {
        Debug.Log("Quit App");
        Application.Quit();
    }
}
