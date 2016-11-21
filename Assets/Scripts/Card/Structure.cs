using UnityEngine;
using System.Collections;

public class Structure : Card {

    protected int fortification;
    protected bool isBuffer;
    protected int timeReq;

    override
    public void effect(){}

    public Structure(string name, int fort, bool ib, int tr)
    {
        cardName = name;
        cardType = CardType.STRUCTURE;
        this.fortification = fort;
        this.isBuffer = ib;
        this.timeReq = tr;
    }

    public Structure()
    {
        cardName = "";
        cardType = CardType.STRUCTURE;
        this.fortification = 0;
        this.isBuffer = false;
        this.timeReq = 0;
    }
}
