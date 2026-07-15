using UnityEngine;

public abstract class PlayerSystem : MonoBehaviour
{
   protected Player player;

    void Awake()
    {
        player = transform.root.GetComponent<Player>();
    }
}