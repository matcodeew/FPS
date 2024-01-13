using UnityEngine;
using UnityEngine.AI;

public class fasterEnemyManager : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent fasterAgent;
    private void Start()
    {
        fasterAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        fasterAgent.destination = target.position;
    }
}
