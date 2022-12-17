using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStack : MonoBehaviour
{
    Stack<Card> pile = new Stack<Card>();
    [SerializeField] CardTracker textTracker;

    public List<Card> Flush()
    {
        if(pile.Count > 0)
        {
            Card lastPlayedCard = pile.Pop();
            List<Card> remainingCards = new List<Card>(pile);
            pile.Clear();
            pile.Push(lastPlayedCard);
            return new List<Card>(remainingCards);
        }
        else
        {
            Debug.LogWarning("The play stack was empty when flush was attempted");
            return new List<Card>();
        }
    }

    public void PlayCard(Card card)
    {
        pile.Push(card);
        textTracker.UpdatePlayStackText(pile.Peek().ToString());
    }

    public Card GetLastPlayedCard() => pile.Peek();
}
