using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] TextMeshProUGUI interactButtonText;
    [SerializeField] List<GameObject> ItemsInInteractCollider = new List<GameObject>();
    [SerializeField] GameObject focusedUI;
    public void Activate()
    {
        if (ItemsInInteractCollider.Count > 0)
        {
            if (ItemsInInteractCollider[0] != null)
            {
                switch (ItemsInInteractCollider[0].tag)
                {
                    case "Item":
                        playerAnimator.PickUp();
                        ItemsInInteractCollider[0].GetComponent<IPickUpAble>().PickUp();
                        ItemsInInteractCollider.RemoveAt(0);
                        break;
                    case "Plant":
                        playerAnimator.Chop();
                        ItemsInInteractCollider[0].GetComponent<IHarvestable>().Harvest(ItemsInInteractCollider);
                        break;
                    case "Placeable":
                        playerAnimator.PickUp();
                        ItemsInInteractCollider[0].GetComponent<IPlaceable>().Place(ItemsInInteractCollider);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    private void Update()
    {
        if (ItemsInInteractCollider.Count > 0)
        {
            focusedUI.SetActive(true);
            focusedUI.transform.position = new Vector3(ItemsInInteractCollider[0].transform.position.x, ItemsInInteractCollider[0].transform.position.y, ItemsInInteractCollider[0].transform.position.z);
            switch (ItemsInInteractCollider[0].tag)
            {
                case "Item":
                    interactButtonText.text = "Pick Up";
                    break;
                case "Plant":
                    interactButtonText.text = "Harvest";
                    break;
                case "Tree":
                    interactButtonText.text = "Chop";
                    break;
                case "Placeable":
                    interactButtonText.text = "Place";
                    break;
                default:
                    interactButtonText.text = "Interact";
                    break;
            }
        }
        else
        {
            interactButtonText.text = "Interact";
            focusedUI.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!ItemsInInteractCollider.Contains(other.gameObject) && other.gameObject.tag != "Player" && other.gameObject.tag != "InteractUI" && other.gameObject.tag != "Untagged")
        {
            ItemsInInteractCollider.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ItemsInInteractCollider.Remove(other.gameObject);
    }
}
