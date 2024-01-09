using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    bool EnemySpawned = false;
    int TotalRound = 10;
    int round;
    int RandomEnemy;
    int countEnemy;
    public int EnemyDead;

    private void Start()
    {
        FirstRound(3, 5);
    }

    private void FirstRound(int minEnemy, int maxEnemy)
    {
        for (round = 0; round < TotalRound; round++)
        {
            if (EnemySpawned == false)
            {
                RandomEnemy = Random.Range(minEnemy, maxEnemy);
                for (int i = 0; i < RandomEnemy; i++)
                {
                    GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
                    countEnemy++;
                }
            }
            if (countEnemy == RandomEnemy)
            {
                EnemySpawned = true;
            }
            if (EnemyDead == countEnemy)
            {
                minEnemy += 2;
                maxEnemy += 2;
                EnemySpawned = false;
            }
        }
    }

}
