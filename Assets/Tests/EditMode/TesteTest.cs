using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TesteTest
    {
        [Test]
        public void TesteTestSimplePasses()
        {
            Assert.AreEqual(randomscript.testInt,6);
        }
    }
}
