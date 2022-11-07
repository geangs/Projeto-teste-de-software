using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class HandTests
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
        public IEnumerator TestHandSizeAfterPlayingCard()
        {

            var deck = GameObject.FindObjectOfType<Deck>();
            var card = deck.DrawCard().GetComponent<CardScript>();
            var hand = GameObject.FindObjectOfType<HandScript>();
            int handSize = hand.cards.Count;
            card.release();
            Assert.AreEqual(handSize,hand.cards.Count);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestHandSizeAfterPlayingMultipleCards()
        {
            
            var deck = GameObject.FindObjectOfType<Deck>();
            var hand = GameObject.FindObjectOfType<HandScript>();
            int handSize = hand.cards.Count;

            for (int i = 0; i < 5; i++)
            {
                var card = deck.DrawCard().GetComponent<CardScript>();
                card.release();
            }

            Assert.AreEqual(handSize,hand.cards.Count);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestSlotCountEqualToMaxHandSize()
        {
            
            var hand = GameObject.FindObjectOfType<HandScript>();
            Assert.AreEqual(hand.slots.Count,Constants.maxHandSize);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator AllInitialCardsAssignedToASlot()
        {
            var hand = GameObject.FindObjectOfType<HandScript>();
            
            
            foreach (var card in hand.cards)
            {
                bool found = false;
                foreach (var slot in hand.slots)
                {
                    if (slot.card == card)
                    {
                        found = true;
                    }
                }
                
                Assert.AreEqual(true,found);
            }
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestCardHasCorrectPositionAfterBeingAssignedToASlot()
        {
            var hand = GameObject.FindObjectOfType<HandScript>();
            var card = hand.cards[2];
            Assert.AreEqual(hand.slots[2].card,card);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator FindCorrectSlot()
        {
            
            var hand = GameObject.FindObjectOfType<HandScript>();
            hand.cards[3].GetComponent<CardScript>().release();
            var slot = hand.findSlot();
            Assert.AreEqual(slot,hand.slots[3]);
            
            yield return null;
        }
        
        
        [UnityTest]
        public IEnumerator TestCardIsAssignedToCorrectSlotAfterFinding()
        {
            
            var deck = GameObject.FindObjectOfType<Deck>();
            var hand = GameObject.FindObjectOfType<HandScript>();
            
            hand.cards[3].GetComponent<CardScript>().release();
            var card = deck.DrawCard();
            hand.fitCard(card);
            
            Assert.AreEqual(hand.FindCardSlot(card),hand.slots[3]);
            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator TestCardLeavesSlotAfterBeingPickedUp()
        {
            var hand = GameObject.FindObjectOfType<HandScript>();
            hand.cards[3].GetComponent<CardScript>().pickUp();
            Assert.AreEqual(null,hand.slots[3].card);
            
            yield return null;
            
        }
        
        [UnityTest]
        public IEnumerator TestCorrectSlotsAreOccupiedAfterOrganizingHand()
        {
            
            var deck = GameObject.FindObjectOfType<Deck>();
            var hand = GameObject.FindObjectOfType<HandScript>();
            var card2 = hand.cards[1];
            hand.cards[0].GetComponent<CardScript>().release();
            
            hand.organizeCards();

            Assert.AreEqual(hand.FindCardSlot(card2),hand.slots[0]);
            
            yield return null;
        }
        
    }
}
