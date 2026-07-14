using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public PlayerEvents Events;
}

public struct PlayerEvents
{
    
}
