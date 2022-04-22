using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable , IPickUpAble
{
    public void PickUp()
    {
        gameObject.SetActive(false);
        PlayerInventory.Instance.AddItem(gameObject);
    }
}
