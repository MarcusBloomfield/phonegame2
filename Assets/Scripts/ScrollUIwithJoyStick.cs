using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUIwithJoyStick : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2;
    [SerializeField] FixedJoystick FixedJoystick;
    [SerializeField] GameObject inventoryHolder;
    [SerializeField] GameObject craftingHolder;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = inventoryHolder.transform.position;
    }
    private void Update()
    {
        Scroll(inventoryHolder);
        Scroll(craftingHolder);
    }
    void Scroll(GameObject holder)
    {
        if (holder.activeInHierarchy && holder.activeSelf)
        {
            holder.transform.position = new Vector3(holder.transform.position.x, holder.transform.position.y + FixedJoystick.Vertical * Time.deltaTime * scrollSpeed, holder.transform.position.z);
        }
        else
        {
            holder.transform.position = initialPosition;
        }
    }
}
