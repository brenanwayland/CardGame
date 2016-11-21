using UnityEngine;
using System.Collections;

public class Basecamp {

    private Player playerOwns;
    private Tile[] allies;
    private Tile[] enemies;
    private Tile[] structures;
    private Environment env;

    public Basecamp(Player po, Environment e)
    {
        this.playerOwns = po;
        this.env = e;

        //initialize tiles
        this.allies = new Tile[4];
        this.enemies = new Tile[4];
        this.structures = new Tile[4];
        for (int i = 0; i < allies.Length; i++)
        {
            allies[i] = new Tile();
            enemies[i] = new Tile();
            structures[i] = new Tile();
        }
    }

    public Player getOwner()
    {
        return playerOwns;
    }

    public Tile[] getAllies()
    {
        return allies;
    }

    public Tile[] getEnemies()
    {
        return enemies;
    }

    public Tile[] getStructures()
    {
        return structures;
    }

    public Environment getEnvironment()
    {
        return env;
    }

    public void changeEnvironment(Environment e)
    {
        env = e;
    }
}
