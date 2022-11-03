using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCards : MonoBehaviour
{
    private GameObject card;
    private bool setToWait = false;
    
    public AllCards allCards;

    private int i = 0;


    public void PlayCard()
    {
        var card = Instantiate(allCards.fireball, new Vector3(0, 0, 0), Quaternion.identity);
        this.card = card;
        setToWait = true;
    }

    void Update()
    {
        if (setToWait)
        {
            i++;
            if (i > 60)
            {
                i = 0;
                setToWait = false;
                card.GetComponent<CardScript>().release();
                card.SetActive(false);
            }
        }
            
    }
    

}
