using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] public GameObject obstacle;
    [SerializeField] public GameObject obstacleParent;
    [SerializeField] private GameObject MapSurface;

    int MaxObs = 100;
    bool ObstacleCreated = false;


    private void Start()
    {
        CreateObstacle();
    }
    private void CreateObstacle()
    {
        if (ObstacleCreated == false)
        {
            for (int i = 0; i < MaxObs; i++)
            {
                GameObject newObstacle = Instantiate(obstacle, MapSurface.transform.position + new Vector3(Random.Range(-200, 200), 2.52f, Random.Range(-200, 200)), Quaternion.identity);
                newObstacle.transform.SetParent(obstacleParent.transform);
            }
            ObstacleCreated = true;
        }
    }
}
