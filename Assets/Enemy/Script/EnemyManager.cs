using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    PlayerShoot shoot;

    public Transform target;
    public NavMeshAgent agent;
    [SerializeField] private GameObject bullet;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination = target.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}

