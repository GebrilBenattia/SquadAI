using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public abstract void OnPossess(Pawn _Pawn);
    public abstract void UnPossess();
}
