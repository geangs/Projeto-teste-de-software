using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthTests
    {

        [UnityTest]
        public IEnumerator TestPlayerStartingHealth()
        {
            Assert.AreEqual(100,GameObject.Find("Health").GetComponent<Health>().value);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestEnemyStartingHealth()
        {
            Assert.AreEqual(100,GameObject.Find("EnemyHealth").GetComponent<Health>().value);
            yield return null;
        }
    }
}
