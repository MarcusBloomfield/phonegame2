using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] PlayerStats playerStats;

    [SerializeField] GameObject inventoryButtonHolder;
    [SerializeField] GameObject inventoryButtonPrefab;
    [SerializeField] List<GameObject> inventoryButtons;
    public void UpdateUI()
    {
        DestroyListOfGameObjects(inventoryButtons);
        CreateInventoryButtons();
    }
    private void DestroyListOfGameObjects(List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            Destroy(item);
        }
        gameObjects.Clear();
    }
    void CreateInventoryButtons()
    {
        if (playerInventory.Inventory.Count > 0)
        {
            foreach (var item in playerInventory.Inventory)
            {
                InventoryButton button = Instantiate(inventoryButtonPrefab, inventoryButtonHolder.transform).GetComponent<InventoryButton>();
                AssignName(button, item);
                AssignWhatButtonBelongsTo(button, item);
                AssignDropFunction(button, item);
                AssignUseFunction(button, item);
                inventoryButtons.Add(button.gameObject);
            }
        }
    }
    void AssignName(InventoryButton button, GameObject item) => button.ItemNameText.text = item.GetComponent<Interactable>().Type;
    void AssignWhatButtonBelongsTo(InventoryButton button, GameObject item) => button.ItemBelongsTo = item;
    void AssignDropFunction(InventoryButton button, GameObject item)
    {
        button.DropButton.onClick.AddListener(() =>
        {
            Drop(playerInventory, item, button.gameObject);
        });
    }
    void AssignUseFunction(InventoryButton button, GameObject item)
    {
        if (item.TryGetComponent<IUseAble>(out IUseAble consumable))
        {
            button.UseButton.onClick.AddListener(() =>
            {
                consumable.Use(playerStats, playerInventory);
                Destroy(button.gameObject);
            });
        }
        else button.UseButton.gameObject.SetActive(false);
    }
    public void Drop(PlayerInventory playerInventory, GameObject item, GameObject button)
    {
        playerInventory.Inventory.Remove(item);
        item.transform.position = playerInventory.PlayerPlaceLocation.transform.position;
        item.SetActive(true);
        Destroy(button);
    }
}
