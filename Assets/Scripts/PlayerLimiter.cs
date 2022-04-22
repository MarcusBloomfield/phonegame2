using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimiter : MonoBehaviour
{
    [SerializeField] int XBounds = 0;
    [SerializeField] int YBounds = 0;
    [SerializeField] int ZBounds = 0;

    private void Update()
    {
        LimitPositive(gameObject.transform.position.x, XBounds, new Vector3(XBounds, gameObject.transform.position.y, gameObject.transform.position.z));
        LimitPositive(gameObject.transform.position.y, YBounds, new Vector3(gameObject.transform.position.x, YBounds, gameObject.transform.position.z));
        LimitPositive(gameObject.transform.position.z, ZBounds, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, ZBounds));
        LimitNegitive(gameObject.transform.position.x, XBounds, new Vector3(-XBounds, gameObject.transform.position.y, gameObject.transform.position.z));
        LimitNegitive(gameObject.transform.position.y, YBounds, new Vector3(gameObject.transform.position.x, -YBounds, gameObject.transform.position.z));
        LimitNegitive(gameObject.transform.position.z, ZBounds, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -ZBounds));
    }
    void LimitPositive(float pos, float boundDistance, Vector3 appliedBounds)
    {
        if (pos > boundDistance)
        {
            gameObject.transform.position = appliedBounds;
        }
    }
    void LimitNegitive(float pos, float boundDistance, Vector3 appliedBounds)
    {
        if (pos < -boundDistance)
        {
            gameObject.transform.position = appliedBounds;
        }
    }
}
