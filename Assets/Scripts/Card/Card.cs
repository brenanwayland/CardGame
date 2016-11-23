using UnityEngine;
using System.Collections;

public class Card {

    protected string cardName;
    protected int cardID;
    protected Effect effect;

    public enum CardRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        SUPER_RARE,
        EXTREMELY_RARE
    }

    protected CardRarity cardRarity;
    
    public enum CardType
    {
        CREATURE,
        STRUCTURE,
        ENVIRONMENT,
        SPELL
    }

    protected CardType cardType;

    public string getCardName()
    {
        return cardName;
    }

    public void setCardName(string name)
    {
        cardName = name;
    }

    public CardType getCardType()
    {
        return cardType;
    }

    public void setCardType(CardType type)
    {
        cardType = type;
    }

    public int getCardID()
    {
        return cardID;
    }

    public void setCardID(int ci)
    {
        cardID = ci;
    }
}

