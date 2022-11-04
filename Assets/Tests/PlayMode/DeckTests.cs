using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class DeckTests
{
    
    [SetUp]
    public void SetUpTest()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    [UnityTest]
    public IEnumerator TestStartingHandSize()
    {
        var hand = GameObject.Find("HandDisplay").GetComponent<HandScript>();
        Assert.AreEqual(5,hand.cards.Count);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestStartingDeckSize()
    {
        var deck = GameObject.Find("Deck").GetComponent<Deck>();
        Assert.AreEqual(15,deck.cards.Count);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestDeckSizeAfterDrawingCard()
    {
        var deck = GameObject.Find("Deck").GetComponent<Deck>();
        var size = deck.cards.Count;
        deck.DrawCard();
        Assert.AreEqual(size,deck.cards.Count+1);
        yield return null;
    }
}
