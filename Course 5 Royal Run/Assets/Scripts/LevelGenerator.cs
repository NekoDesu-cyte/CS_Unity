using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLenght = 0f;

    private void Start() 
    {
        for (int i = 0; i < startingChunkAmmount; i++)
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

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent); 
        }
    }
}
