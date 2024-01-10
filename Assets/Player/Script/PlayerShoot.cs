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

    public void Shoot()
    {
        FireParticules.Stop();
        FireParticules.Play();

        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, transform.TransformDirection(Vector3.left), out hit, 15f))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "Core")
            {
                Destroy(hit.transform.gameObject);
                enemy.EnemyDead++;
            }  
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