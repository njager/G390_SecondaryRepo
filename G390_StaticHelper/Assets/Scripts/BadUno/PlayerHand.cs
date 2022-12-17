using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class PlayerHand : MonoBehaviour
{
    public List<Card> hand = new List<Card>();
    public int startingHandCount = 7;
    public Deck drawPile;
    public PlayStack playStack;
    public CardTracker textTracker;
    private void Start()
    {
        drawPile.PostDeckGenerated.AddListener(DrawStart);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var card in hand)
            {
                if (PlayCard(card))
                {
                    if(hand.Count == 0)
                    {
                        textTracker.UpdateWinText();
                        textTracker.UpdateAllText("", "");
                    }
                    return;
                }
                
            }
            DrawCard(1);
            
        }
    }
    public void DrawStart() => DrawCard(startingHandCount);
    public void DrawCard(int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            hand.Add(drawPile.DrawCard());
        }
        textTracker.UpdatePlayerHandText(ListCurrentHand());
        //hyper optimized
    }

    bool PlayCard(Card cardToPlay)
    {
        if (CanPlayCard(cardToPlay))
        {
            playStack.PlayCard(cardToPlay);
            hand.Remove(cardToPlay);
            textTracker.UpdatePlayerHandText(ListCurrentHand());
            //textTracker.UpdateAllText(ListCurrentHand(), playStack.GetLastPlayedCard().ToString());
            return true;
        }
        else
        {
            Debug.Log($"{cardToPlay} is not a valid choice to play on {playStack.GetLastPlayedCard()}");
            return false;
        }
    }

    bool CanPlayCard(Card cardToCheck)
    {
        Card cardOnPile = playStack.GetLastPlayedCard();
        if(cardToCheck.number == cardOnPile.number || cardToCheck.color == cardOnPile.color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string ListCurrentHand()
    {
        StringBuilder handList = new StringBuilder();
        foreach(Card card in hand)
        {
            handList.AppendLine($"- {card.ToString()}");
        }
        return handList.ToString();
    }

    private void OnDestroy()
    {
        drawPile.PostDeckGenerated.RemoveListener(DrawStart);
    }
}
