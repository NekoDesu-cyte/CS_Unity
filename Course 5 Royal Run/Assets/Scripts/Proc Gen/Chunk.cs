using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float[] lanes = {-2.5f, 0, 2.5f};

    List<int>availableLanes = new List<int>{0, 1, 2};

    LevelGenerator levelGenerator;
    ScoreManager scoreManager;  

    void Start() 
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }

    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }
    void SpawnFences()
    {
        
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
    void SpawnApple()
    {
        if (Random.value > appleSpawnChance||availableLanes.Count <= 0) return;
        if (availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.init(levelGenerator);
    }

    void SpawnCoin()
    {
        if (Random.value > coinSpawnChance||availableLanes.Count <= 0) return;
        
        int selectedLane = SelectLane();
        int coinToSpawn = Random.Range(1, 6);
        float coinSpacing = 1.5f;

        for (int i = 0; i < coinToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z + (i * coinSpacing));
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();  
            newCoin.Init(scoreManager);
        }
    }
    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
