using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable, IHarvestable
{
    int chopAmount = 5;
    [SerializeField] int maxRandomItemSpawnAmount = 3;
    [SerializeField] List<GameObject> produce = new List<GameObject>();
    [SerializeField] List<GameObject> biProducts = new List<GameObject>();

    public List<GameObject> Produce { get => produce; set => produce = value; }
    public List<GameObject> BiProducts { get => biProducts; set => biProducts = value; }

    private void Start()
    {
        for (int i = 0; i < Random.Range(0, maxRandomItemSpawnAmount); i++)
        {
            BiProducts.Add(AssetManager.Instance.RawItems[Random.Range(0, AssetManager.Instance.RawItems.Count)]);
        }
    }
    public void Harvest(List<GameObject> Items)
    {
        chopAmount -= 1;
        if (chopAmount <= 0)
        {
            gameObject.SetActive(false);
            SpawnListOfGameObjects(produce);
            SpawnListOfGameObjects(biProducts);
            Items.Remove(gameObject);
        }
    }
    void SpawnListOfGameObjects(List<GameObject> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Instantiate(items[i], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + i, gameObject.transform.position.z), gameObject.transform.rotation).GetComponent<Rigidbody>().AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
    }
}
