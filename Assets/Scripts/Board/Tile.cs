using UnityEngine;
using System.Collections;

public class Tile {

    private Card cardHere;

    public Card getCardHere()
    {
        return cardHere;
    }

    public void putCardHere(Card card)
    {
        cardHere = card;
    }

    public void removeCard()
    {
        cardHere = null;
    }
}
