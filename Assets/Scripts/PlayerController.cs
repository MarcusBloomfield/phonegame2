using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float turnSpeed = 102;
    [SerializeField] float moveSpeed = 102;

    private void Update()
    {
        gameObject.transform.position += gameObject.transform.forward * fixedJoystick.Vertical * Time.deltaTime * moveSpeed;
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + turnSpeed * fixedJoystick.Horizontal * Time.deltaTime, gameObject.transform.eulerAngles.z);
    }
}
