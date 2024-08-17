using System.Collections;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject normalEnemy;
    [SerializeField] private GameObject FasterEnemy;

    [SerializeField] private GameObject fasterEnemyParent;
    [SerializeField] private GameObject normalEnemyParent;

    [SerializeField] private fasterEnemyManager yellowEnemy;
    [SerializeField] private EnemyManager redEnemy;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerShoot playerShoot;

    [SerializeField] public TextMeshProUGUI roundMesh;

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
        roundMesh.text = " round : " + (TotalRound - roundwin).ToString();
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
                playerShoot.ClearEnemyInfo();
                yield return new WaitForSeconds(3.0f);
                Spawn();
                yield return new WaitForSeconds(2.0f);
            }
            yield return null;
        }
    }

    void Spawn()
    {
        RoundStarted = true;
        minEnemy += 10;
        maxEnemy += 10;
        redEnemy.normalAgent.speed += 1f;
        yellowEnemy.fasterAgent.speed += 1f;
        RandomEnemy = Random.Range(minEnemy, maxEnemy);

        Vector3 playerPos = player.transform.position;

        for (EnemySpawn = 0; EnemySpawn < RandomEnemy; EnemySpawn++)
        {
            RandomTypeEnemy = Random.Range(0, 2);
            if(RandomTypeEnemy == 0)
            {
                GameObject newEnemy = Instantiate(normalEnemy, playerPos + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
                newEnemy.transform.SetParent(normalEnemyParent.transform);
            }
            else if (RandomTypeEnemy == 1)
            {
                GameObject newEnemy = Instantiate(FasterEnemy, playerPos + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
                newEnemy.transform.SetParent(fasterEnemyParent.transform);
            }
        }
        playerShoot.UpdateTextInfo();
    }

    public void Verif()
    {
        if (EnemyDead == RandomEnemy)
        {
            roundwin++;
            EnemyDead = 0;

            roundMesh.text = " round : " + (TotalRound - roundwin).ToString();

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