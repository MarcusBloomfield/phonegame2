using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float starveationRate = .1f;
    [SerializeField] float maxHunger = 100;
    [SerializeField] float hunger = 100;
    [SerializeField] float hungerDegrade = 1;

    public float Hunger { get => hunger; set => hunger = value; }
    public float Health { get => health; set => health = value; }

    private void Update()
    {
        DegradeHunger();
        Starve();
        Die();
    }
    void DegradeHunger() => Hunger -= hungerDegrade * Time.deltaTime;
    void Starve()
    {
        if (hunger <= 0) health -= starveationRate;
    }
    void Die()
    {
        if (health <= 0)
        {
            Debug.Log("ded");
        }
    }
}
