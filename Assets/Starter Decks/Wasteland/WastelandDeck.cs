using UnityEngine;
using System.Collections;

public class WastelandDeck : Deck {

    private void loadCreatures()
    {
        
    }

    private void loadStructures()
    {

    }

    private void loadSpells()
    {

    }

    private void loadEnvironments()
    {

    }

    public WastelandDeck()
    {
        name = "Wasteland Starter Deck";
        loadCreatures();
        loadStructures();
        loadSpells();
        loadEnvironments();
        Debug.Log("Wasteland Deck 1st constructor called");
    }

    public WastelandDeck(string name, Card[] e, Card[] c, Card[] st, Card[] sp) : base(name, e, c, st, sp)
    {
        Debug.Log("Wasteland Deck 2nd constructor called");
    }
}
