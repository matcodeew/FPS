using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    public bool EnemySpawned = false;
    public int TotalRound = 10;
    int roundwin;
    public int RandomEnemy;
    public int countEnemy;
    public int EnemyDead;

    List<int> round;

    void RoundToWin()
    {
        round.Add(roundwin);
    }

}
