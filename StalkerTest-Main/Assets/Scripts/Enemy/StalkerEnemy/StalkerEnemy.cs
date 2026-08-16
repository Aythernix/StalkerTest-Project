using System;
using UnityEngine;

public class StalkerEnemy : Enemy
{
    public StalkerEnemyEvents StalkerEvents;
    void Start()
    {
        StalkerEvents = new StalkerEnemyEvents();
    }
}


