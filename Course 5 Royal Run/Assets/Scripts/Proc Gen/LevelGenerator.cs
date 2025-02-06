using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraControl cameraControl;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLenght = 10f;
    [SerializeField] float moveSpeed  = 8f;
    [SerializeField] float minMoveSpeed = 2f;

    List<GameObject> chunks = new List<GameObject>();
   

    private void Start()
    {
        SpawnStartingChunks();
    }
    private void Update() {
        moveChunk();
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunkAmmount; i++)
        {
            SpawnChunk();
        }
    }
    public void ChangeChunkMoveSPeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

        cameraControl.ChangeCameraFOV(speedAmount);
    }
    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLenght;
        }

        return spawnPositionZ;
    }
    void moveChunk()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLenght)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
            
        }
    }
}
