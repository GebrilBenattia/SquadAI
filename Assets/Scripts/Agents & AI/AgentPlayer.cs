using TMPro;
using UnityEngine;

public class AgentPlayer : Agent
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI m_TextPlayerLife;
    [SerializeField] private Camera m_ViewCamera;

    // Agent Player Settings
    [Header("Agent Player Settings")]
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_DamageCauserCacheDuration;

    // Private Variables
    private ShootSystem m_ShootSystem;
    private Agent m_NearestDamageCauser;
    private Vector3 m_LookAtPos;
    private bool m_IsShooting;
    private float m_DamageCauserCacheTime;

    // Getter / Setter
    public Vector3 lookAtPos => m_LookAtPos;
    public bool isShooting => m_IsShooting;
    public Agent nearestDamageCauser => m_NearestDamageCauser;
    public float damageCauserCacheDuration => m_DamageCauserCacheDuration;

    private void Awake()
    {
        _health = _maxHealth;
        m_ShootSystem = GetComponent<ShootSystem>();
    }

    private void FaceMouse()
    {
        m_LookAtPos = MouseUtilities.GetMouseWorldPos(m_ViewCamera);
        Vector3 directionToFace = m_LookAtPos - transform.position;

        // Ensure we only rotate on the Y-axis (no vertical rotation)
        directionToFace.y = 0;

        SetLookRotation(Quaternion.LookRotation(directionToFace));
    }

    private void Move(Vector3 _Direction)
    {
        transform.position += _Direction * m_MoveSpeed * Time.deltaTime;
    }

    private void SetNearestDamageCauser(Agent _DamageCauser)
    {
        m_NearestDamageCauser = _DamageCauser;
        m_DamageCauserCacheTime = m_DamageCauserCacheDuration;
    }

    protected override void EventGetDamaged(Agent _DamageCauser)
    {
        if (m_NearestDamageCauser == null) {
            SetNearestDamageCauser(_DamageCauser);
        }
        else {
            float distance1 = Vector3.Distance(transform.position, m_NearestDamageCauser.transform.position);
            float distance2 = Vector3.Distance(transform.position, _DamageCauser.transform.position);
            if (distance2 <= distance1) {
                SetNearestDamageCauser(_DamageCauser);
            }
        }
    }

    private void Update()
    {
        // Update Nearest Damage Causer Cache Time
        if (m_DamageCauserCacheTime > 0f) {
            m_DamageCauserCacheTime -= Time.deltaTime;
        }
        else if (m_DamageCauserCacheTime <= 0f) {
            m_NearestDamageCauser = null;
        }

        // Update text life
        m_TextPlayerLife.text = "Life: " + _health.ToString() + "/" + _maxHealth.ToString();

        // Face to Mouse
        FaceMouse();

        // Update movements
        Vector3 moveVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Move(moveVelocity.normalized);

        // Shoot
        if (Input.GetMouseButton(0)) {
            m_IsShooting = true;
            m_ShootSystem.Fire();
        }
        else {
            m_IsShooting = false;
        }
    }
}