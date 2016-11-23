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
    public Basecamp getBasecamp(int no)
    {
        //TODO: throw exception for inputs other than 1 and 2
        if (no == 1)
        {
            return basecamp1;
        } else if (no == 2)
        {
            return basecamp2;
        } else
        {
            return basecamp1;
        }
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

    //movement logic
    //TODO: add logic for zones being full, and handle how to put creatures onto tiles once moved
    public bool move(Creature ct, Zone og, Zone dest)
    {
        bool success = true;
        if (og.getZoneType() == dest.getZoneType())
        {
            success = false;
        }

        if (og.getZoneType() == Zone.ZoneType.BASECAMP) //player is trying to move into the Warground from either their own Basecamp or their opponent's
        {

            Basecamp current = (Basecamp)og;
            if (current.getOwner() == ct.getOwner()) //player is trying to move a creature out of their own Basecamp
            {

                if (current.enemiesOccupy())
                {
                    success = false;
                }

            }

        } else if (og.getZoneType() == Zone.ZoneType.WARGROUND) // player is trying to move into either their own Basecamp or their opponent's from the Warground
        {
            Warground current = (Warground)og;
            Basecamp bcdest = (Basecamp)dest;
            if (ct.getOwner() != bcdest.getOwner()) // player is trying to move into enemy Basecamp
            {

                if (ct.getOwner().getPlayerNum() == 1) // first player is moving
                {

                    if (current.checkOccupancyCreatures2() > 0) // enemy Basecamp is blocked in the Warground
                    {
                        success = false;
                    }

                }

            } 

        }
        ct.setCurrentLocation(dest);
        return success;
    }
}
