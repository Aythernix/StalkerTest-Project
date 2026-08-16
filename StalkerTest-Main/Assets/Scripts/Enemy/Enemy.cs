using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
   public EnemyData Data;

   public GameObject enemyBody;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         enemyBody = gameObject;
    }
}
