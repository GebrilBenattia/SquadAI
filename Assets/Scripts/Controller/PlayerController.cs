using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Controller
{
    public Pawn controlledPawn;

    public override void OnPossess(Pawn _Pawn)
    {
        controlledPawn = _Pawn;
    }

    public override void UnPossess()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlledPawn != null) {
            Camera.main.transform.LookAt(controlledPawn.transform.position);
        }
    }
}
