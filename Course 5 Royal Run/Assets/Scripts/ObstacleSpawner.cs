using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    int obstacleSpawned = 0;
    void Start() 
    {
        StartCoroutine(spawnObstacleRoutine());
    }  

    IEnumerator spawnObstacleRoutine()
    {
        while (obstacleSpawned < 5)
        {
            yield return new WaitForSeconds(obstacleSpawned);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
            obstacleSpawned++;
        }      
    }
}
