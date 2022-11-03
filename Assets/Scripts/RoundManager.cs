using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public HandScript HandScript;
    public Deck deck;
    public EnemyCards enemyCards;

    void Start()
    {
        Debug.Log("round");
        HandScript.cards = GetInitialHand();
        for (int i = 0; i < 10; i++)
        {
            HandScript.slots.Add(new HandScript.Slot(i));
        }
        HandScript.organizeCards();
    }

    public void NextTurn()
    {
        enemyCards.PlayCard();
    }

    public List<GameObject> GetInitialHand()
    {
        return deck.GetInitialHand();
    }
}
