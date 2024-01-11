using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] SpawnEnemy enemy;

    public ParticleSystem FireParticules;
    public Transform FirePoint;
    public Transform hitpoint;
    public ParticleSystem DeadParticule;

    private Vector3 enemypos;

    private void Awake()
    {
        DeadParticule.Stop();
        FireParticules.Stop();
    }
    public void Shoot()
    {
        FireParticules.Play();

        RaycastHit hit;
        Ray ray = new Ray(bulletSpawn.transform.position, bulletSpawn.transform.forward);
        if (Physics.Raycast(ray, out hit, 25f))
        {
            enemypos = hit.transform.position;
            if (hit.collider.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
                StartCoroutine(anim());
                enemy.EnemyDead++;
            }  
        }
    }

    private IEnumerator anim()
    {
        hitpoint.transform.position = enemypos;
        DeadParticule.Play();
        yield return new WaitForSeconds(1f);
        DeadParticule.Stop();
        yield return null;
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