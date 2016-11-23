using UnityEngine;
using System.Collections;

public class SpellTemplate : Spell {

    public SpellTemplate()
    {
        cardName = "";
        manaCost = 0;
    }

    public SpellTemplate(string name, int mc) : base(name, mc)
    {

    }
}
