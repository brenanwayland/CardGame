using UnityEngine;
using System.Collections;

public class Player {

    private int playerNum;
    private Deck deck;
    private string playerName;
    private int lifeblood;
    private int mana;
    private Card[] inPlay;

    public Card[] getCardsInPlay()
    {
        return inPlay;
    }

    public string getName()
    {
        return playerName;
    }

    public bool useLifeblood(int i)
    {
        bool success = true;
        if (i > lifeblood - 1)
        {
            success = false;
        }
        else
        {
            lifeblood -= i;
        }
        return success;
    }

    public void regainLifeblood(int i)
    {
        lifeblood += i;
    }

    public void directDamage(int i)
    {
        lifeblood -= i;
        if (lifeblood < 0)
        {
            lifeblood = 0;
        }
    }

    public bool useMana(int i)
    {
        bool success = true;
        if (i > mana)
        {
            success = false;
        } else
        {
            mana -= i;
        }
        return success;
    }

    public void regainMana(int i)
    {
        mana += i;
    }

    public bool isDefeated()
    {
        return lifeblood > 0;
    }

    public Deck getDeck()
    {
        return deck;
    }

    public int getPlayerNum()
    {
        return playerNum;
    }

    public Player(int pn, Deck d, string pna, int lb, int m)
    {
        this.playerNum = pn;
        this.deck = d;
        this.playerName = pna;
        this.lifeblood = lb;
        this.mana = m;
    }


}
