using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public UnityEvent growEvent = new UnityEvent();
    [SerializeField] float growTime = 10;
    [SerializeField] float growTimer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Update() 
    {
        GrowAllFarmPlants();
    }
    void GrowAllFarmPlants()
    {
        growTimer += 1 * Time.deltaTime;
        if (growTimer > growTime)
        {
            growEvent.Invoke();
            growTimer = 0;
        }
    }
}
