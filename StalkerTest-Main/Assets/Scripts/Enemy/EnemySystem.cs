using UnityEngine;

public abstract class EnemySystem : MonoBehaviour
{
    protected Enemy enemy;

    void Awake()
    {
        enemy = transform.root.GetComponent<Enemy>();
    }
}
