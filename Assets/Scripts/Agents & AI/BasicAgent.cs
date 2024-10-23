using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : Agent
{
    private void Update()
    {
        if (_isDead) Destroy(gameObject);
    }
}
