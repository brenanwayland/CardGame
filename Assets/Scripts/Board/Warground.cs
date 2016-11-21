using UnityEngine;
using System.Collections;

public class Warground {

    private Tile[] creatures1;
    private Tile[] creatures2;
    private Environment env;

    public Tile[] getCreatures1()
    {
        return creatures1;
    }

    public int checkOccupancyCreatures1()
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            if (creatures1[i].getCardHere() != null)
            {
                count++;
            }
        }
        return count;
    }

    public int checkOccupancyCreatures2()
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            if (creatures2[i].getCardHere() != null)
            {
                count++;
            }
        }
        return count;
    }

    public bool moveIntoCreatures1(Tile tile)
    {
        Creature creature = (Creature) tile.getCardHere();
        bool success = true;
        if (checkOccupancyCreatures1() >= 4)
        {
            success = false;
        } else
        {
            for (int i = 0; i < 4; i++)
            {
                if (creatures1[i].getCardHere() == null)
                {
                    creatures1[i].putCardHere(creature);
                    tile.removeCard();
                }
            }
        }
        return success;
    }

    public bool moveIntoCreatures2(Tile tile)
    {
        Creature creature = (Creature)tile.getCardHere();
        bool success = true;
        if (checkOccupancyCreatures2() >= 4)
        {
            success = false;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (creatures2[i].getCardHere() == null)
                {
                    creatures2[i].putCardHere(creature);
                    tile.removeCard();
                }
            }
        }
        return success;
    }

    public Tile[] getCreatures2()
    {
        return creatures2;
    }

    public Environment getEnvironment()
    {
        return env;
    }

    public void changeEnvironment(Environment e)
    {
        env = e;
    }

    public Warground(Environment e)
    {
        this.env = e;
        creatures1 = new Tile[4];
        creatures2 = new Tile[4];
        for (int i = 0; i < creatures1.Length; i++)
        {
            creatures1[i] = new Tile();
            creatures2[i] = new Tile();
        }
    }
}
