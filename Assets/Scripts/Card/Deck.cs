using UnityEngine;
using System.Collections;

public class Deck : Card {

    protected string name;

    protected Card[] environments;
    protected Card[] creatures;
    protected Card[] structures;
    private Card[] spells;
    protected Card[] battleDeck;

    protected int deckSize;
    protected int creatureNum;
    protected int structureNum;
    protected int spellNum;
    protected int envSize;

    /*public Card draw()
    {
        return battleDeck[deckSize--];
    }*/

    public Deck(string name, Card[] e, Card[] c, Card[] st, Card[] sp)
    {
        this.name = name;
        this.environments = e;
        this.envSize = e.Length;
        this.creatures = c;
        this.structures = st;
        this.spells = sp;

        this.creatureNum = creatures.Length;
        this.structureNum = structures.Length;
        this.spellNum = spells.Length;
        this.deckSize = creatureNum + structureNum + spellNum;

        // put drawable cards into Battle Deck
        battleDeck = new Card[deckSize];
        creatures.CopyTo(battleDeck, 0);
        structures.CopyTo(battleDeck, creatures.Length);
        spells.CopyTo(battleDeck, creatures.Length + structures.Length);
    }

    public Deck()
    {
        this.name = "";
        this.environments = new Card[10];
        this.envSize = 10;
        this.creatures = new Card[20];
        this.structures = new Card[10];
        this.spells = new Card[15];
        this.deckSize = 45;
        this.creatureNum = 20;
        this.structureNum = 10;
        this.spellNum = 15;
    }
}
