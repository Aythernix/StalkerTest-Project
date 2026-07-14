using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public PlayerEvents Events;

    public enum MovementStates
    {
        Walking,
        Sprinting,
        Crouching,   
    }
    
}

public struct PlayerEvents
{
    
}
