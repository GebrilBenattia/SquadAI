using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BulletData", menuName = "Bullet Data")]
public class BulletDataSO : ScriptableObject
{
    // ######################################### VARIABLES ########################################

    // Bullet Settings
    [Header("Bullet Settings")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float lifeTime;

    // ######################################### FUNCTIONS ########################################

    public void Spawn(Vector3 _Position, Quaternion _Rotation, int _OwnerTeamIndex)
    {
        var bulletInst = Instantiate(prefab, _Position, _Rotation).GetComponent<Bullet>();
        bulletInst.Init(this, _OwnerTeamIndex);
    }
}
