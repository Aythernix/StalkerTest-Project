using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    Player player;

    void Awake()
    {
        player = transform.root.GetComponent<Player>();
    }
}