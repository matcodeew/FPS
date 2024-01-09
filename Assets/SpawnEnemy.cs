using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    bool EnemySpawned = false;

    int RandomEnemy;
    private void Start()
    {
        FirstRound(2,5);
    }

    private void FirstRound (int minEnemy , int maxEnemy) 
    {
        RandomEnemy = Random.Range(minEnemy,maxEnemy);

        if (EnemySpawned == false)
        {
            for (int i = 0; i < RandomEnemy; i++)
            {
                GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);

                if (i == RandomEnemy)
                {
                    EnemySpawned = true;
                }
                else if (i > RandomEnemy)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

}
