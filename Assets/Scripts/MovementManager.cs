using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryUI;
    [SerializeField] GameObject CraftingUI;
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerController2 playerController2;
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] Camera camera1;
    [SerializeField] Camera camera2;
    public enum playerControllerType { type1, type2}
    playerControllerType currentControllerType = playerControllerType.type1;
    private void Start()
    {
        ChangeType();
    }
    private void Update()
    {
        switch (currentControllerType)
        {
            case playerControllerType.type1:
                if (InventoryUI.activeSelf || CraftingUI.activeSelf)
                {
                    playerController.enabled = false;
                    playerAnimator.enabled = false;
                }
                else
                {
                    playerAnimator.enabled = true;
                    playerController.enabled = true;
                }
                break;
            case playerControllerType.type2:
                if (InventoryUI.activeSelf || CraftingUI.activeSelf)
                {
                    playerController2.enabled = false;
                    playerAnimator.enabled = false;
                }
                else
                {
                    playerAnimator.enabled = true;
                    playerController2.enabled = true;
                }
                break;
            default:
                break;
        }
    }
    public void ChangeType()
    {
        switch (currentControllerType)
        {
            case playerControllerType.type1:
                playerController2.enabled = true;
                playerController.enabled = false;
                camera1.enabled = false;
                camera2.enabled = true;
                currentControllerType = playerControllerType.type2;
                break;
            case playerControllerType.type2:
                playerController.enabled = true;
                playerController2.enabled = false;
                camera1.enabled = true;
                camera2.enabled = false;
                currentControllerType = playerControllerType.type1;
                break;
            default:
                break;
        }
    }
}
