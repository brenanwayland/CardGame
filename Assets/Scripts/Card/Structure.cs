using UnityEngine;
using System.Collections;

public class Structure : Card {

    private int fortification;
    private bool isBuffer;
    private int timeReq;

    public Structure(string name, int fort, bool ib, int tr)
    {
        setCardName(name);
        setCardType(CardType.STRUCTURE);
        this.fortification = fort;
        this.isBuffer = ib;
        this.timeReq = tr;
    }
}
