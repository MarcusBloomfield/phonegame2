using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 initialPosition;
    [SerializeField] float moveMagnitude =10;
    private void Start()
    {
        initialPosition = gameObject.transform.position;
    }
    private void Update()
    {
        if (!IsVisible(gameObject.transform.position, gameObject.GetComponent<BoxCollider>().bounds.size, Camera.main))
        {
            StartCoroutine(MoveBackOnScreen());
        }
    }
    IEnumerator MoveBackOnScreen()
    {
        yield return new WaitForSeconds(.2f);
        player.transform.position = Vector3.MoveTowards(player.transform.position, initialPosition, moveMagnitude * Time.deltaTime);
    }
    bool IsVisible(Vector3 pos, Vector3 boundSize, Camera camera)
    {
        var bounds = new Bounds(pos, boundSize);
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
