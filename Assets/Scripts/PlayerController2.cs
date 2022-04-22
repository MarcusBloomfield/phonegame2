using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float moveSpeed = 102;

    private void Update()
    {
        if (fixedJoystick.Direction.x != 0 && fixedJoystick.Direction.y != 0)
        {
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * moveSpeed;
            gameObject.transform.LookAt(new Vector3(fixedJoystick.Direction.x * 1000, 1, fixedJoystick.Direction.y * 1000));
        }

    }
}
