using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;

    private void Start() {
        Instantiate(chunkPrefab, transform.position, quaternion.identity);
    }
}
