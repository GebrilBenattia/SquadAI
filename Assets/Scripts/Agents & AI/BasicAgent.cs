public class BasicAgent : Agent
{
    private void Update()
    {
        if (_isDead) Destroy(gameObject);
    }
}
