using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public List<GameObject> cards;
    public List<Slot> slots = new List<Slot>();

    public class Slot
    {
        public int index;
        public GameObject card;

        public Slot(int index)
        {
            this.index = index;
        }

        public void setCard(GameObject card)
        {
            this.card = card;
            PositionCard();
        }

        public void PositionCard()
        {
            var cardTransform = card.GetComponent<Transform>();
            cardTransform.position = new Vector3(index*3-4,-4);
        }
    }

    private void Start()
    {

    }
    

    public void organizeCards()
    {
        foreach(var card in cards)
        {
            var slot = findSlot();
            slot.setCard(card);
        }
    }

    public void fitCard(GameObject card)
    {
        var slot = findSlot();
        slot.setCard(card);
    }

    public Slot findSlot()
    {
        foreach (var slot in slots)
        {
            if (slot.card == null || !slot.card.active)
            {
                return slot;
            }
        }

        return null;
    }

    public void pickUp(GameObject card)
    {
        foreach (var slot in slots)
        {
            if (slot.card == card)
            {
                slot.card = null;
                return;
            }
        }
    }

    public Slot FindCardSlot(GameObject card)
    {
        foreach (var slot in slots)
        {
            if (slot.card == card)
            {
                return slot;
            }
        }

        return null;
    }
}
