using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Interactable, IPlaceable, IUseAble, IPickUpAble
{
    [SerializeField] GameObject plant;
    public void PickUp()
    {
        gameObject.SetActive(false);
        PlayerInventory.Instance.AddItem(gameObject);
    }
    public void Place(List<GameObject> Items)
    {
        Instantiate(plant, gameObject.transform.position, gameObject.transform.rotation);
        Items.Remove(gameObject);
        Destroy(gameObject);
    }
    public void Use(PlayerStats playerStats, PlayerInventory playerInventory)
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        gameObject.SetActive(true);
        playerInventory.Inventory.Remove(gameObject);
        gameObject.transform.position = playerInventory.PlayerPlaceLocation.transform.position;
        gameObject.transform.parent = playerInventory.PlayerPlaceLocation.transform;
        gameObject.tag = "Placeable";
    }
}
