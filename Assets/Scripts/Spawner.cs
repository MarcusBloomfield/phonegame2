using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int spawnAmountRocks = 25;
    [SerializeField] int spawnAmountPlants = 25;
    [SerializeField] int spawnAmountTrees = 25;
    [SerializeField] float boundsX = 25;
    [SerializeField] float boundsZ = 25;
    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        AssetManager assetManager = AssetManager.Instance;
        SpawnList(assetManager.Trees, spawnAmountTrees);
        SpawnList(assetManager.Rocks, spawnAmountRocks, 1);
        SpawnList(assetManager.Plants, spawnAmountPlants);
    }
    void SpawnList(List<GameObject> gameObject, int amount)
    {
        for (int k = 0; k < amount; k++)
        {
            Instantiate(gameObject[Random.Range(0,gameObject.Count)], new Vector3(Random.Range(-boundsX, boundsX), 0, Random.Range(-boundsZ, boundsZ)), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }
    void SpawnList(List<GameObject> gameObject, int amount, float spawnHieght)
    {
        for (int k = 0; k < amount; k++)
        {
            Instantiate(gameObject[Random.Range(0, gameObject.Count)], new Vector3(Random.Range(-boundsX, boundsX), spawnHieght, Random.Range(-boundsZ, boundsZ)), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }
}
