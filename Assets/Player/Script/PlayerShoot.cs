using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] SpawnEnemy spawnenemy;
    [SerializeField] private GameObject Bullet ;

    public ParticleSystem FireParticules;
    public Transform FirePoint;
    public Transform hitpoint;
    public ParticleSystem DeadParticule;
    public ParticleSystem HealParticule;

    private Vector3 enemypos;

    public int ammount = 10;

    private void Awake()
    {
        DeadParticule.Stop();
        FireParticules.Stop();
        HealParticule.Stop();
    }
    public void Shoot()
    {
        if(ammount > 0)
        {
            FireParticules.Play();
            ammount--;
            Debug.Log(ammount);
            RaycastHit hit;
            Ray ray = new Ray(bulletSpawn.transform.position, bulletSpawn.transform.forward);
            if (Physics.Raycast(ray, out hit, 30f))
            {
                enemypos = hit.transform.position;
                if (hit.collider.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                    StartCoroutine(anim());
                    spawnenemy.EnemyDead++;
                }
            }
        }
    }

    private IEnumerator anim()
    {
        hitpoint.transform.position = enemypos;
        SpawnHealOrbs();
        DeadParticule.Play();
        yield return new WaitForSeconds(1f);
        DeadParticule.Stop();
        yield return null;
    }

    private void SpawnHealOrbs()
    {
        int GenerateRandomNumber = Random.Range(0, 6);
        if(GenerateRandomNumber == 1)
        {
            GameObject NewBullet = Instantiate(Bullet,new Vector3(enemypos.x, 0.5f, enemypos.z), Quaternion.identity);
            HealParticule.Play();
        }
    }
    public void ClearOldParticles()
    {
        ParticleSystem[] particles = FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            if (particle.isPlaying)
            {
                float duration = particle.main.duration + particle.main.startLifetime.constant;
                Destroy(particle.gameObject, duration);
            }
        }
    }
}