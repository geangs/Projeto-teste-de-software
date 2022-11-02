using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public List<GameObject> cards;

    private void Start()
    {
        Debug.Log("hand");
        organizeCards();
    }

    public void organizeCards()
    {

        float i = -4f;
        foreach(var card in cards)
        {
            var cardTransform = card.GetComponent<Transform>();
            cardTransform.position = new Vector3(i,-4);
            i += 3;
        }
    }
}
