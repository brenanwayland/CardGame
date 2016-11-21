using UnityEngine;
using System.Collections;

public class Spell : Card {
    protected int manaCost;

    override
    public void effect()
    { }

    public Spell()
    {
        cardName = "";
        cardType = CardType.SPELL;
        manaCost = 0;
        
    }

    public Spell(string name, int mc)
    {
        cardName = name;
        manaCost = mc;
    }
}
