using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLenght = 10f;
    [SerializeField] float moveSpeed  = 8f;

    GameObject[] chunks = new GameObject[12];

    private void Start()
    {
        SpawnChunks();
    }
    private void Update() {
        moveCHunk();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < startingChunkAmmount; i++)
        {
            float spawnPositionZ = CalculateSpawnPositionZ(i);

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

            chunks[i] = newChunk;
        }
    }

    private float CalculateSpawnPositionZ(int i)
    {
        float spawnPositionZ;

        if (i == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = transform.position.z + (i * chunkLenght);
        }

        return spawnPositionZ;
    }
    void moveCHunk()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
        }
    }
}
