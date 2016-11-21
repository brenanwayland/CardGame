using UnityEngine;
using System.Collections;

public class SpellTemplate : Spell {

    override
    public void effect()
    {

    }

    public SpellTemplate()
    {
        cardName = "";
        manaCost = 0;
    }

    public SpellTemplate(string name, int mc) : base(name, mc)
    {

    }
}
