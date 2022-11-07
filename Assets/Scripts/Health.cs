using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int value = 100;
    public string type;
    public TextMeshPro result;

    public void addHealth(int amount)
    {

        if (value + amount < Constants.maxHealth)
            value += amount;
        else
            value = Constants.maxHandSize;
        
        GetComponentInChildren<TextMeshPro>().text = "Health: " + value;

        if (amount <= 0)
        {
            if (type == "player")
            {
                result.text = Constants.defeatText;
            }

            if (type == "enemy")
            {
                result.text = Constants.victoryText;
            }
        }
    }
}
