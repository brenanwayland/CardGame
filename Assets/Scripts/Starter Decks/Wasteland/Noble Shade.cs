using UnityEngine;
using System.Collections;

public class NobleShade : Creature {


    public NobleShade()
    {
        cardName = "Noble Shade";
        vitality = 10;
        strength = 12;
        guard = 10;
        creatureType = CreatureType.DEMON;
        creatureClass = CreatureClass.PALADIN;
    }

    public NobleShade(string name, int v, int st, int g, CreatureType ct, CreatureClass cc) : base(name, v, st, g, ct, cc)
    {

    }

}
