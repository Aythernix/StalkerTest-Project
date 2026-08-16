using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StalkerData", menuName = "Scriptable Objects/StalkerData")]
public class StalkerData : EnemyData
{
    // contains data specific to the enemy type
    // Such as special data
}

public struct StalkerEnemyEvents
{
    // Events specific to the enemy type
    public Action OnDeath;
}