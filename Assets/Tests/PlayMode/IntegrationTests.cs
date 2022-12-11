using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
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
            SceneManager.LoadScene("GameScene");
        }
        
        
        [UnityTest]
        public IEnumerator TestBuyCard()
        {
            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            
            
//            fakeConnection.send("get_coins player");
//            string oldCoins = fakeConnection.response;
//            fakeConnection.send("add_coins player 100 ");
//            fakeConnection.send("buy_card player fireball");
//            fakeConnection.send("card_unlocked fireball");
//            Assert.AreEqual(,fakeConnection.response);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestSellCard()
        {
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerGainsScoreAfterWinningAGame()
        {
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerGainsScoreAfterLosingAGame()
        {
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestPlayerCoins()
        {

            var fakeConnection = GameObject.Find("FakeConnection").GetComponent<FakeConnection>();
            
            
            fakeConnection.send("get_coins player ");
            yield return new WaitForSeconds(1);
            //Assert.AreEqual("601",fakeConnection.response);

            yield return null;
        }
        
    }
}

