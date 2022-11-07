using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class ReferenceTests
    {
        [SetUp]
        public void SetUpTest()
        {
            SceneManager.LoadScene("GameScene");
        }
        
        [UnityTest]
        public IEnumerator TestReferenceCardName()
        {
            var card = GameObject.Find("Deck").GetComponent<Deck>().DrawCard();
            Assert.AreEqual(card.transform.FindChild("Front/Name").GetComponent<TextMeshPro>(),card.GetComponent<CardScript>().name);
            yield return null;

        }
        
        [UnityTest]
        public IEnumerator TestReferenceCardText()
        {
            var card = GameObject.Find("Deck").GetComponent<Deck>().DrawCard();
            Assert.AreEqual(card.transform.FindChild("Front/Text").GetComponent<TextMeshPro>(),card.GetComponent<CardScript>().text);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestReferenceCardSpriteRenderer()
        {
            var card = GameObject.Find("Deck").GetComponent<Deck>().DrawCard();
            Assert.AreEqual(card.transform.FindChild("Front/Card art").GetComponent<SpriteRenderer>(),card.GetComponent<CardScript>().spriteRenderer);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestReferenceCardDraggableCardReference()
        {
            var card = GameObject.Find("Deck").GetComponent<Deck>().DrawCard();
            Assert.NotNull(card.GetComponent<Draggable>());
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestReferenceEndTurnButtonRoundManagerReference()
        {
            
            var button = GameObject.Find("Endturn").GetComponent<EndTurnButton>();
            Assert.AreEqual(button.roundManager,GameObject.FindObjectOfType(typeof(RoundManager)));
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestReferenceHealthText()
        {
            var health = GameObject.Find("Health").GetComponent<Health>();
            Assert.AreEqual(health.GetComponentInChildren<TextMeshPro>(),health.GetComponentInChildren<TextMeshPro>());
            yield return null;
            
        }
        
        [UnityTest]
        public IEnumerator TestReferenceEnemyHealthText()
        {
            var health = GameObject.Find("EnemyHealth").GetComponent<Health>();
            Assert.AreEqual(health.GetComponentInChildren<TextMeshPro>(),health.GetComponentInChildren<TextMeshPro>());
            yield return null;
            
        }
        
        [UnityTest]
        public IEnumerator TestReferenceRoundManagerHandScript()
        {

            var manager = GameObject.FindObjectOfType<RoundManager>();
            Assert.AreEqual(manager.HandScript,GameObject.FindObjectOfType<HandScript>());
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestReferenceRoundManagerDeck()
        {
            var manager = GameObject.FindObjectOfType<RoundManager>();
            Assert.AreEqual(manager.deck,GameObject.FindObjectOfType<Deck>());
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestReferenceRoundManagerEnemyCards()
        {
            var manager = GameObject.FindObjectOfType<RoundManager>();
            Assert.AreEqual(manager.enemyCards,GameObject.FindObjectOfType<EnemyCards>());
            yield return null;
        }
        
    }
}
