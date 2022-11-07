using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCards : MonoBehaviour
{
    private GameObject card;
    private bool setToWait = false;
    
    public AllCards allCards;

    private int i = 0;
    private int j = 0;
    
    public GameObject PlayCard()
    {

        if (j == 0)
        {
            var card = Instantiate(allCards.fireball, new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<Draggable>().draggable = false;
            card.GetComponent<CardScript>().cardAction.target = GameObject.Find("Health");
            this.card = card;
            setToWait = true;
            j = 20;
            return card;
        }

        return null;
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
                GameObject.Find("RoundManager").GetComponent<RoundManager>().playerTurn = true;
                GameObject.FindObjectOfType<EndTurnButton>().canClick = true;
            }
        }

        if (j != 0)
        {
            j--;
        }
            
    }
    

}
