using System.Collections;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

[SuppressMessage("ReSharper", "AccessToStaticMemberViaDerivedType")]
public class CardTests
{

    [SetUp]
    public void SetUpTest()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    
    [UnityTest]
    public IEnumerator TestPlayerDamagesEnemy()
    {
        var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Fireball.prefab",
            typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
        card.GetComponent<CardScript>().cardAction.target = GameObject.Find("EnemyHealth");
        card.GetComponent<CardScript>().release();
        Assert.AreEqual(94,GameObject.Find("EnemyHealth").GetComponent<Health>().value);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestPlayerHeals()
    {
        var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Heal.prefab",
            typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
        card.GetComponent<CardScript>().cardAction.target = GameObject.Find("Health");
        card.GetComponent<CardScript>().release();
        Assert.AreEqual(105,GameObject.Find("Health").GetComponent<Health>().value);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestEnemyDamagesPlayer()
    {
        GameObject.Find("RoundManager").GetComponent<RoundManager>().NextTurn();
        yield return new WaitForSeconds(3f);
        Assert.AreEqual(94,GameObject.Find("Health").GetComponent<Health>().value);
    }
    
    [UnityTest]
    public IEnumerator TestReturnCardToHand()
    {
        var hand = GameObject.FindObjectOfType<HandScript>();
        var card = hand.cards[3].GetComponent<CardScript>();
        card.transform.Translate(0, 1, 0);
        card.release2();
        Assert.AreEqual(card,hand.cards[3].GetComponent<CardScript>());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestPlayCard()
    {
        var hand = GameObject.FindObjectOfType<HandScript>();
        var card = hand.cards[3].GetComponent<CardScript>();
        card.transform.Translate(0, 5, 0);
        card.release2();
        Assert.AreEqual(null,hand.slots[3].card);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestCardIsDisabledAfterPlaying()
    {
        var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Fireball.prefab",
            typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
        var cardScript = card.GetComponent<CardScript>();
        cardScript.cardAction.target = GameObject.Find("EnemyHealth");
        cardScript.release();
        Assert.AreEqual(false,card.active);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestCardIsPlayedAfterReleasingIt()
    {
        var hand = GameObject.FindObjectOfType<HandScript>();
        var card = hand.cards[0];
        card.GetComponent<CardScript>().release();
        Assert.IsFalse(card.active);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestEnemyCardDisappearAfterBeingPlayed()
    {

        var enemy = GameObject.FindObjectOfType<EnemyCards>();
        var card = enemy.PlayCard();
        yield return new WaitForSeconds(2.5f);
        Assert.AreEqual(false,card.active);
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestEnemyCardsAreNotDraggable()
    {

        var enemy = GameObject.FindObjectOfType<EnemyCards>();
        var card = enemy.PlayCard();
        Assert.AreEqual(false,card.GetComponent<Draggable>().draggable);
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestEnemyCardsAreNotPlayable()
    {

        var enemy = GameObject.FindObjectOfType<EnemyCards>();
        var card = enemy.PlayCard();
        Assert.AreEqual(false,!card.GetComponent<CardScript>().playable);
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestFireball()
    {
            
        var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Fireball.prefab",
            typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
        card.GetComponent<CardScript>().cardAction.target = GameObject.Find("EnemyHealth");
        card.GetComponent<CardScript>().release();
        Assert.AreEqual(94,GameObject.Find("EnemyHealth").GetComponent<Health>().value);
        yield return null;
    }
    
    
    [UnityTest]
    public IEnumerator TestHeal()
    {
        var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Heal.prefab",
            typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
        card.GetComponent<CardScript>().cardAction.target = GameObject.Find("Health");
        card.GetComponent<CardScript>().release();
        Assert.AreEqual(105,GameObject.Find("Health").GetComponent<Health>().value);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestAllPlayerCardArePlayable()
    {

        var hand = GameObject.FindObjectOfType<HandScript>();

        foreach (var card in hand.cards)
        {
            Assert.AreEqual(true,card.GetComponent<CardScript>().playable);
        }
        
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator TestAllPlayerCardAreDraggable()
    {

        var hand = GameObject.FindObjectOfType<HandScript>();

        foreach (var card in hand.cards)
        {
            Assert.AreEqual(true,card.GetComponent<Draggable>().draggable);
        }
        
        
        yield return null;
    }
    

}
