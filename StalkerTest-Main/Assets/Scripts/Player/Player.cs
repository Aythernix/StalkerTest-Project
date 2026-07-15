using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData Data;

    void Start()
    {
        Data.playerCamera = Camera.main.transform.gameObject;
        Data.playerBody = gameObject;
    }
}
