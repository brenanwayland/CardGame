using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck {

    protected string name;

    private List<Card> environments;
    private List<Card> creatures;
    private List<Card> structures;
    private List<Card> spells;
    private List<Card> battleDeck;

    private int deckSize;
    private int creatureNum;
    private int structureNum;
    private int spellNum;
    private int envSize;

    public List<Card> getEnvironments()
    {
        return environments;
    }

    public List<Card> getCreatures()
    {
        return creatures;
    }

    public List<Card> getStructures()
    {
        return structures;
    }

    public List<Card> getSpells()
    {
        return spells;
    }

    public List<Card> getBattleDeck()
    {
        return battleDeck;
    }

    public Card draw()
    {
        return battleDeck[deckSize--];
    }

    public Deck(string name, List<Card> e, List<Card> c, List<Card> st, List<Card> sp)
    {
        this.name = name;
        this.environments = e;
        this.envSize = e.Count;
        this.creatures = c;
        this.structures = st;
        this.spells = sp;

        this.creatureNum = creatures.Count;
        this.structureNum = structures.Count;
        this.spellNum = spells.Count;
        this.deckSize = creatureNum + structureNum + spellNum;

        // put drawable cards into Battle Deck
        battleDeck = new List<Card>();
        battleDeck.AddRange(creatures);
        battleDeck.AddRange(structures);
        battleDeck.AddRange(spells);
    }

    public Deck()
    {
        this.name = "";
        this.environments = new List<Card>();
        this.envSize = 10;
        this.creatures = new List<Card>();
        this.structures = new List<Card>();
        this.spells = new List<Card>();
        this.deckSize = 45;
        this.creatureNum = 20;
        this.structureNum = 10;
        this.spellNum = 15;
    }
}
