using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Basecamp : Zone {

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

        this.zoneType = ZoneType.BASECAMP;
    }

    //getters and setters
    public Player getOwner()
    {
        return playerOwns;
    }

    public Tile[] getAllies()
    {
        return allies;
    }

    public bool alliesOccupy()
    {
        return allies.Length > 0;
    }

    public Tile[] getEnemies()
    {
        return enemies;
    }

    public bool enemiesOccupy()
    {
        return enemies.Length > 0;
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

    //card tracking
    public List<Card> getAllCards()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 4; i++)
        {

        }
        return list;
    }

    public List<Creature> getAllCreatures()
    {
        List<Creature> list = new List<Creature>();
        return list;
    }

    public List<Creature> getAlliedCreatures()
    {
        List<Creature> list = new List<Creature>();
        return list;
    }

    public List<Creature> getEnemyCreatures()
    {
        List<Creature> list = new List<Creature>();
        return list;
    }

    public List<Structure> getAllStructures()
    {
        List<Structure> list = new List<Structure>();
        return list;
    }
}
