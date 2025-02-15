using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;

    PlayerHealth player;


    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>(); 
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while(player)
        {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
        }
    }
}
