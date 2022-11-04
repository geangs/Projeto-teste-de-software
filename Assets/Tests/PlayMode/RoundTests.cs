using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RoundTests
    {
        
        [UnityTest]
        public IEnumerator TestPlayerTurnAfterEnemyPlaysCard()
        {
            GameObject.Find("Endturn").GetComponent<EndTurnButton>().endTurn();
            yield return new WaitForSeconds(1.5f);
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
    }
}
