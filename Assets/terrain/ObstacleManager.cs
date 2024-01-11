using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject MapSurface;

    int MaxObs = 50;
    bool ObstacleCreated = false;


    private void Start()
    {
        obstacle = GetComponent<GameObject>();
        CreateObstacle();
    }
    private void CreateObstacle()
    {
        if (ObstacleCreated == false)
        {
            for (int i = 0; i < MaxObs; i++)
            {
                GameObject newObstacle = Instantiate(obstacle, MapSurface.transform.position + new Vector3(Random.Range(-200, 200), 0, Random.Range(-200, 200)), Quaternion.identity);
            }
            ObstacleCreated = true;
        }
    }

}
