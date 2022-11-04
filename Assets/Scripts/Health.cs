using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int value = 100;

    public void addHealth(int amount)
    {
        value += amount;
        GetComponentInChildren<TextMeshPro>().text = "Health: " + value;
    }
}
