using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("blocker hit");
        Destroy(collision.gameObject);
    }
}
