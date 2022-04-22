using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] InventoryUI InventoryUI;
    [SerializeField] GameObject CraftingUI;

    private void Start()
    {
        DeactivateAllUI();
    }
    void DeactivateAllUI()
    {
        InventoryUI.gameObject.SetActive(false);
        CraftingUI.SetActive(false);
    }
    void OpenClose(GameObject gameObject)
    {
        if (gameObject.activeSelf == false)
        {
            DeactivateAllUI();
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }
    public void OpenInventory()
    {
        InventoryUI.UpdateUI();
        OpenClose(InventoryUI.gameObject);
    }
    public void OpenCrafting() => OpenClose(CraftingUI);
}
