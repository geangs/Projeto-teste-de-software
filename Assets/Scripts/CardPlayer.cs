using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    
    public static GameObject selectedCard;

    void OnMouseUp()
    {
        Debug.Log("asdfasdf");
        selectedCard?.GetComponent<CardScript>().release();
        selectedCard = null;

    }
    
    void OnMouseDown()
    {
        Debug.Log("asdfasdf");

    }
}
