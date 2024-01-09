using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] SpawnEnemy enemy;

    public void Shoot()
    { 
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.transform.position, transform.TransformDirection(Vector3.left), out hit, 10f))
        {
            if (hit.collider.name == "Core")
            {
                Destroy(hit.transform.gameObject);
                enemy.EnemyDead++;
            }
        }
    }   
}
