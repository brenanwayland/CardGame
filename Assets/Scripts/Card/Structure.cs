using UnityEngine;
using System.Collections;

public class Structure : Card {

    protected int fortification;
    protected bool isBuffer;
    protected int timeReq;

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

    public int getFort()
    {
        return fortification;
    }

    public void setFort(int i)
    {
        this.fortification = i;
    }

    public bool checkBuffer()
    {
        return isBuffer;
    }

    public void setAsBuffer()
    {
        this.isBuffer = true;
    }

    public int getTimeReq()
    {
        return timeReq;
    }

    public void timeReqUp(int i)
    {
        timeReq += i;
    }

    public void timeReqDown(int i)
    {
        timeReq -= i;
    }
}
