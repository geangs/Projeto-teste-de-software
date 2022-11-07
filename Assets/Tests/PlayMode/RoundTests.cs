using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class RoundTests
    {
        
        [SetUp]
        public void SetUpTest()
        {
            SceneManager.LoadScene("GameScene");
        }
        
        
        [UnityTest]
        public IEnumerator TestPlayerTurnAfterEnemyPlaysCard()
        {
            GameObject.Find("Endturn").GetComponent<EndTurnButton>().endTurn();
            yield return new WaitForSeconds(3f);
            Assert.AreEqual(true,GameObject.Find("RoundManager").GetComponent<RoundManager>().playerTurn);
            yield return null;
        }
        
        
        [UnityTest]
        public IEnumerator TestEndRoundButton()
        {
            GameObject.Find("Endturn").GetComponent<EndTurnButton>().endTurn();
            Assert.AreEqual(false,GameObject.Find("RoundManager").GetComponent<RoundManager>().playerTurn);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerWinsWhenEnemyHasZeroHealth()
        {    
            var enemyHealth = GameObject.Find("EnemyHealth");
            enemyHealth.GetComponent<Health>().addHealth(-100);
            var textBox = GameObject.Find("GameResultText").GetComponent<TextMeshPro>();
            Assert.AreEqual(Constants.victoryText,textBox.text);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerLosesWhenTheyHaveZeroHealth()
        {    
            var health = GameObject.Find("Health");
            health.GetComponent<Health>().addHealth(-100);
            var textBox = GameObject.Find("GameResultText").GetComponent<TextMeshPro>();
            Assert.AreEqual(Constants.defeatText,textBox.text);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator PlayerGoesFirst()
        {
            var manager = GameObject.FindObjectOfType<RoundManager>();
            Assert.AreEqual(true,manager.playerTurn);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerCantEndTurnOnEnemyTurn()
        {
            var button = GameObject.FindObjectOfType<EndTurnButton>();
            button.endTurn();
            Assert.IsFalse(button.canClick);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerDamagesEnemyUntilWinning()
        {
            int amount = Constants.startingHealth / 6 + 1;
            for (int i = 0; i < amount; i++)
            {
                var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Fireball.prefab",
                    typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<CardScript>().cardAction.target = GameObject.Find("EnemyHealth");
                card.GetComponent<CardScript>().release();
            }
            
            var enemyHealth = GameObject.Find("EnemyHealth");
            var textBox = GameObject.Find("GameResultText").GetComponent<TextMeshPro>();
            Assert.AreEqual(Constants.victoryText,textBox.text);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerCantHealMoreThanMaxHealth()
        {
            
            var health = GameObject.Find("Health");
            health.GetComponent<Health>().addHealth(200);
            
            var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Heal.prefab",
                typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<CardScript>().cardAction.target = GameObject.Find("Health");
            card.GetComponent<CardScript>().release();
            Assert.AreEqual(200,GameObject.Find("Health").GetComponent<Health>().value);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestFireballReference()
        {
            var cards = GameObject.FindObjectOfType<AllCards>();
            Assert.NotNull(cards.fireball);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestHealReference()
        {
            var cards = GameObject.FindObjectOfType<AllCards>();
            Assert.NotNull(cards.heal);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestDrawCardFromEmptyDeck()
        {

            var deck = GameObject.FindObjectOfType<Deck>();

            for (int i = 0; i < 15; i++)
            {
                deck.DrawCard();
            }
            
            Assert.Null(deck.DrawCard());
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestAllPlayerCardsHaveTargets()
        {

            var hand = GameObject.FindObjectOfType<HandScript>();

            foreach (var card in hand.cards)
            {
                Assert.NotNull(card.GetComponent<CardScript>().cardAction.target);
            }
            
            yield return null;
        }
    }
}
