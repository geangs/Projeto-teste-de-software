using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

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
        yield return new WaitForSeconds(1.5f);
        Assert.AreEqual(94,GameObject.Find("Health").GetComponent<Health>().value);
    }
    
    [UnityTest]
    public IEnumerator TestReturnCardToHand()
    {
        GameObject.Find("RoundManager").GetComponent<RoundManager>().NextTurn();
        yield return new WaitForSeconds(1.5f);
        Assert.AreEqual(94,GameObject.Find("Health").GetComponent<Health>().value);
    }
    
}
