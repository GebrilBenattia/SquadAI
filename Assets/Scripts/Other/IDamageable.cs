using UnityEngine;
using System.Collections.Generic;

interface IDamageable
{
    void AddDamage(float _Damage, Agent _DamageCauser);
}