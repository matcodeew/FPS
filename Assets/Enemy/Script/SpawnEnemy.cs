using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    public int TotalRound;
    int roundwin;
    public int RandomEnemy;
    public int EnemySpawn;
    public int EnemyDead;
    bool RoundStarted = false;
    int minEnemy = 3;
    int maxEnemy = 5;

    private void Start()
    {
        ResetValue();
        StartCoroutine(StartRounds());
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
        RandomEnemy = Random.Range(minEnemy, maxEnemy) + 1;
        Debug.Log(RandomEnemy);
        for (EnemySpawn = 0; EnemySpawn < RandomEnemy; EnemySpawn++)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
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