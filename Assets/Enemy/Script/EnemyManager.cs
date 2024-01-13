using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent normalAgent;

    private void Start()
    {
        normalAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        normalAgent.destination = target.position;
    }

}