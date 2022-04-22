using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject playerPlaceLocation;
    [SerializeField] List<GameObject> inventory = new List<GameObject>();


    static PlayerInventory instance;
    public static PlayerInventory Instance { get { return instance; } }

    public List<GameObject> Inventory { get => inventory; set => inventory = value; }
    public GameObject PlayerPlaceLocation { get => playerPlaceLocation; set => playerPlaceLocation = value; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddItem(GameObject item)
    {
        if (item != null)
        {
            Inventory.Add(item);
        }
    }
}
