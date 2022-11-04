using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    
    public static GameObject selectedCard;

    void OnMouseUp()
    {
        selectedCard?.GetComponent<CardScript>().release();
        selectedCard = null;
        
    }
    
}
