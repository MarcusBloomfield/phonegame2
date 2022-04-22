using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlant : Interactable, IHarvestable
{
    bool isGrown = false;
    int chopAmount = 5;
    int currentGrowState = 0;
    [SerializeField] List<GameObject> growStates = new List<GameObject>();
    [SerializeField] List<GameObject> produce = new List<GameObject>();

    public List<GameObject> Produce { get => produce; set => produce = value; }
    
    public void Harvest(List<GameObject> Items)
    {
        chopAmount -= 1;
        if (chopAmount <= 0)
        {
            gameObject.SetActive(false);
            if(isGrown) SpawnListOfGameObjects(produce);
            Items.Remove(gameObject);
        }
    }
    private void Start()
    {
        GameManager.Instance.growEvent.AddListener(Grow);
        for (int i = 0; i < growStates.Count; i++)
        {
            growStates[i].SetActive(false);
        }
        growStates[0].SetActive(true);
    }
    void Grow()
    {
        if (currentGrowState < growStates.Count -1)
        {
            growStates[currentGrowState].SetActive(false);
            currentGrowState += 1;
            growStates[currentGrowState].SetActive(true);
        }
        else
        {
            isGrown = true;
            GameManager.Instance.growEvent.RemoveListener(Grow);
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
