using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deck : MonoBehaviour
{
    public List<Card> cardCollection = new List<Card>();
    public Stack<Card> deck = new Stack<Card>();
    public PlayStack playStack;

    public UnityEvent PostDeckGenerated;

    private void Start()
    {
        GenerateCardsForDeck();
    }
    void GenerateCardsForDeck()
    {
        /*for (int i = 0; i < 4; i++)
        {
            CardColor color = (CardColor)i;
            for (int n = 0;  n < 10;  n++)
            {
                Card newCard = new Card(i, color);
                cardCollection.Add(newCard);
            }
        }*/
        foreach(CardColor color in System.Enum.GetValues(typeof(CardColor)))
        {
            for (int i = 0; i <= 9; i++)
            {
                Card newCard = new Card(i, color);
                cardCollection.Add(newCard);
            }
        }
        print(cardCollection.Count);
        deck = ShuffleDeck(cardCollection);
        PostDeckGenerated?.Invoke();
        playStack.PlayCard(deck.Pop());
    }

    Stack<Card> ShuffleDeck(List<Card> incomingDeck)
    {
        //the container for the deck getting built
        Stack<Card> newDeck = new Stack<Card>();

        int loopAttempts = 0;
        while(incomingDeck.Count > 0 && loopAttempts < 100)
        {
            int cardIndex = Random.Range(0, incomingDeck.Count);
            newDeck.Push(incomingDeck[cardIndex]);
            incomingDeck.Remove(newDeck.Peek());
            loopAttempts++;
        }

        return newDeck;
    }

    public Card DrawCard()
    {
        if(deck.Count == 0)
        {
            deck = ShuffleDeck(playStack.Flush());
            return deck.Pop();
        }
        else
        {
            return deck.Pop();
        }
        
    }
}
