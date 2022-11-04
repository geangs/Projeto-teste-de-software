using System.Collections;
using System.Collections.Generic;
using log4net.Util;
using UnityEditor;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<GameObject> cards;
    public AllCards AllCards;
    

    void Start()
    {    
        Debug.Log("deck");
        AllCards = GetComponent<AllCards>();
        cards = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {    
            
            var card = (GameObject)Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Fireball.prefab",
                typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<CardScript>().cardAction.target = GameObject.Find("EnemyHealth");
            
            card.SetActive(false);
            cards.Add(card);

        }
        
        for (int i = 0; i < 10; i++)
        {    
            var card = (GameObject)Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Heal.prefab",
                typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<CardScript>().cardAction.target = GameObject.Find("Health");
            card.SetActive(false);
            cards.Add(card);

        }
    }

    void Update()
    {
        
    }

    public GameObject DrawCard()
    {
        var card = cards[Random.Range(0,cards.Count-1)];
        card.SetActive(true);
        cards.Remove(card);
        return card;
    }

    public List<GameObject> GetInitialHand()
    {
        var hand = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            hand.Add(DrawCard());
        }

        return hand;
    }
}
