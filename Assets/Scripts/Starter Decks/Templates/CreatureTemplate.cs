using UnityEngine;
using System.Collections;

public class CreatureTemplate : Creature {


    public CreatureTemplate()
    {
        cardName = "";
        vitality = 0;
        strength = 0;
        guard = 0;
        creatureType = CreatureType.MAN;
        creatureClass = CreatureClass.GRUNT;
    }

    public CreatureTemplate(string name, int v, int st, int g, CreatureType ct, CreatureClass cc) : base(name, v, st, g, ct, cc)
    {

    }

}
