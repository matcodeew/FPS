using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject normalEnemy;
    [SerializeField] private GameObject FasterEnemy;

    [SerializeField] private fasterEnemyManager yellowEnemy;
    [SerializeField] private EnemyManager redEnemy;

    public int TotalRound;
    public int roundwin;
    int RandomEnemy;
    public int EnemySpawn;
    public int EnemyDead;
    bool RoundStarted = false;
    int minEnemy = 1;
    int maxEnemy = 10;
    int RandomTypeEnemy;

    private void Start()
    {
        ResetValue();
        StartCoroutine(StartRounds());
        redEnemy.normalAgent.speed = 7;
        yellowEnemy.fasterAgent.speed = 11;
    }

    private IEnumerator StartRounds()
    {
        while (roundwin < TotalRound)
        {
            if (!RoundStarted)
            {
                Spawn();
                yield return new WaitForSeconds(2f);
            }
            yield return null;
        }
    }

    private void Update()
    {
        Verif();
    }

    void Spawn()
    {
        RoundStarted = true;
        minEnemy += 10;
        maxEnemy += 10;
        redEnemy.normalAgent.speed += 1f;
        yellowEnemy.fasterAgent.speed += 1f;
        Debug.Log(" red : " + redEnemy.normalAgent.speed + " : " + "yellow : " + yellowEnemy.fasterAgent.speed);
        RandomEnemy = Random.Range(minEnemy, maxEnemy) + 1;
        for (EnemySpawn = 0; EnemySpawn < RandomEnemy; EnemySpawn++)
        {
            RandomTypeEnemy = Random.Range(0, 2);
            if(RandomTypeEnemy == 0)
            {
                GameObject newEnemy = Instantiate(normalEnemy, transform.position + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            }
            else if (RandomTypeEnemy == 1)
            {
                GameObject newEnemy = Instantiate(FasterEnemy, transform.position + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            }
        }
    }

    private void Verif()
    {
        if (EnemyDead == RandomEnemy)
        {
            roundwin++;
            EnemyDead = 0;

            RoundStarted = false;
        }
    }

    private void ResetValue()
    {
        EnemyDead = 0;
        EnemySpawn = 0;
        RandomEnemy = 0;
        roundwin = 0;
    }
}