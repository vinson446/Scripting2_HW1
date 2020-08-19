using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI treasureText;

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        healthText.text = "HP: " + currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void UpdateTreasureText(int treasure)
    {
        treasureText.text = "Treasure: " + treasure.ToString();
    }
}
