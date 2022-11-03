using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public CardData data;
    public new TextMeshPro name, text;
    public SpriteRenderer spriteRenderer;
    public CardAction cardAction;


    void Start()
    {
        name.text = data.name;
        text.text = data.text;
        spriteRenderer.sprite = data.sprite;

    }

    public void release()
    {
        cardAction.play();
    }

    public void pickUp()
    {
        GameObject.Find("HandDisplay").GetComponent<HandScript>().pickUp(transform.gameObject);
    }
    
}
