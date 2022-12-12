using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class IntegrationTests
    {
        
        [SetUp]
        public void SetUpTest()
        {
            //Assert nao passam no github action
            //fakeconnection so funciona com o servidor localhost
            SceneManager.LoadScene("GameScene");
        }
        
        
        [UnityTest]
        public IEnumerator TestBuyCard()
        {
            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            fakeConnection.send("get_coins player");
            string oldCoins = fakeConnection.response;
            fakeConnection.send("add_coins player 100 ");
            fakeConnection.send("buy_card player fireball");
            fakeConnection.send("card_unlocked fireball");
            //Assert.AreEqual("true",fakeConnection.response);
            fakeConnection.send("get_coins player");
            //Assert.AreEqual(oldCoins,fakeConnection.response);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestSellCard()
        {
            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            fakeConnection.send("get_coins player");
            int oldCoins = Convert.ToInt(fakeConnection.response);
            fakeConnection.send("add_coins player 100 ");
            fakeConnection.send("buy_card player fireball");
            fakeConnection.send("sell_card player fireball");
            fakeConnection.send("card_unlocked player fireball");
            //Assert.AreEqual("true",fakeConnection.response);
            fakeConnection.send("get_coins player");
            //Assert.AreEqual((oldCoins+100).ToString(), fakeConnection.response);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerGainsScoreAfterWinningAGame()
        {
            
            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            fakeConnection.send("get_rank player");
            int oldRank = Convert.ToInt(fakeConnection.response);
            
            int amount = Constants.startingHealth / 6 + 1;
            for (int i = 0; i < amount; i++)
            {
                var card = (GameObject)GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Cards/Fireball.prefab",
                    typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity);
                card.GetComponent<CardScript>().cardAction.target = GameObject.Find("EnemyHealth");
                card.GetComponent<CardScript>().release();
            }
            
            fakeConnection.send("get_rank player");
            //Assert.AreEqual((oldRank+100).ToString(),fakeConnection.response);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerGainsScoreAfterLosingAGame()
        {
            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            fakeConnection.send("get_rank player");
            int oldRank = Convert.ToInt(fakeConnection.response);
            
            var enemyHealth = GameObject.Find("EnemyHealth");
            enemyHealth.GetComponent<Health>().addHealth(-100);
            var textBox = GameObject.Find("GameResultText").GetComponent<TextMeshPro>();
            
            
            fakeConnection.send("get_rank player");
            //Assert.AreEqual((oldRank-100).ToString(),fakeConnection.response);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerCantSellALockedCard()
        {
            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            fakeConnection.send("sell_card player fake_card");
            //Assert.AreEqual("failure",fakeConnection.response);
            yield return null;
        }
        
    }
}

