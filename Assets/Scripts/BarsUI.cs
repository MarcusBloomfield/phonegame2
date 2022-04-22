using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsUI : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RectTransform healthBar;
    [SerializeField] RectTransform foodBar;

    private void Update()
    {
        foodBar.sizeDelta = new Vector2(playerStats.Hunger * 2, foodBar.sizeDelta.y);
        healthBar.sizeDelta = new Vector2(playerStats.Health * 2, foodBar.sizeDelta.y);
    }
}
