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
    public bool playable = true;


    void Start()
    {
        name.text = data.name;
        text.text = data.text;
        spriteRenderer.sprite = data.sprite;

    }

    public void release()
    {
        if(playable)
            cardAction.play();
    }

    public void pickUp()
    {
        GameObject.Find("HandDisplay").GetComponent<HandScript>().pickUp(transform.gameObject);
    }

    public void setPlayable(bool playable)
    {
        this.playable = playable;
        GetComponent<Draggable>().draggable = playable;
    }

    public void release2()
    {
        if (transform.position.y > -2)
        {
            pickUp();
            release();
        }
        else
        {
            GameObject.Find("HandDisplay").GetComponent<HandScript>().fitCard(transform.gameObject);
        }
    }

}
