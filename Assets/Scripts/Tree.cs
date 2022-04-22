using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactable, IHarvestable, IPickUpAble
{
    int chopAmount = 5;
    public void Harvest(List<GameObject> Items)
    {
        chopAmount -= 1;
        if (chopAmount <= 0)
        {
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddForce(Vector3.forward, ForceMode.Impulse);
            }
            Items.Remove(gameObject);
            StartCoroutine(TimeUntilFrozen());
            gameObject.tag = "Untagged";
        }
    }
    public void PickUp()
    {
        gameObject.SetActive(false);
        PlayerInventory.Instance.AddItem(gameObject);
        gameObject.AddComponent<Rigidbody>();
    }

    IEnumerator TimeUntilFrozen()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.tag = "Item";
    }
}
