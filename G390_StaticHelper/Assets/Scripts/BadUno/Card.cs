using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public int number;
    public CardColor color;

    public Card(int number, CardColor color)
    {
        this.number = number;
        this.color = color;
    }

    public override string ToString()
    {
        return $"{color} - {number}";
    }
}
public enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}
