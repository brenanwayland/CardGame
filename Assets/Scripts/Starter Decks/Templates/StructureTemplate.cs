using UnityEngine;
using System.Collections;

public class StructureTemplate : Structure {

    public StructureTemplate()
    {
        cardName = "";
        fortification = 0;
        isBuffer = false;
        timeReq = 0;
    }

    public StructureTemplate(string name, int f, bool ib, int tr) : base(name, f, ib, tr)
    {

    }
}
