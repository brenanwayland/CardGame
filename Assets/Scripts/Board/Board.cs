using UnityEngine;
using System.Collections;

public class Board {

    private Basecamp basecamp1;
    private Basecamp basecamp2;
    private Warground warground;

    public Board(Basecamp bc1, Basecamp bc2, Warground wg)
    {
        this.basecamp1 = bc1;
        this.basecamp2 = bc2;
        this.warground = wg;
    }

    // Basecamp 1 getters & setters
    public Basecamp getBasecamp1()
    {
        return basecamp1;
    }

    public void setBasecamp1(Basecamp bc)
    {
        basecamp1 = bc;
    }

    // Basecamp 2 
    public Basecamp getBasecamp2()
    {
        return basecamp2;
    }

    public void setBasecamp2(Basecamp bc)
    {
        basecamp2 = bc;
    }

    // Warground
    public Warground getWarground()
    {
        return warground;
    }

    public void setWarground(Warground wg)
    {
        warground = wg;
    }
}
