using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public HandScript HandScript;
    public Deck deck;

    void Start()
    {
        Debug.Log("round");
        HandScript.cards = GetInitialHand();
        HandScript.organizeCards();
    }

    void Update()
    {
        
    }

    public List<GameObject> GetInitialHand()
    {
        return deck.GetInitialHand();
    }
}
