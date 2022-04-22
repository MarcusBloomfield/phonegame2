using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item, IUseAble
{
    [SerializeField] float foodRestore = 10;
    public void Use(PlayerStats playerStats, PlayerInventory playerInventory)
    {
        playerStats.Hunger += 10;
        playerInventory.Inventory.Remove(gameObject);
        Destroy(gameObject);
    }
}
