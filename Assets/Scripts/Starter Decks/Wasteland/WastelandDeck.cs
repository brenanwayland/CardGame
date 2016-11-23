using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class WastelandDeck : Deck {
    private List<Card> deck = new List<Card>();
    private JsonData crtData;
    private JsonData envData;
    private JsonData strData;
    private JsonData spData;
   
    //helper class to parse JSON string into CreatureType enum 
    private Creature.CreatureType setType(string input)
    {
        if (input == "Man")
        {
            return Creature.CreatureType.MAN;
        } else if (input == "Elf")
        {
            return Creature.CreatureType.ELF;
        } else if (input == "Dwarf")
        {
            return Creature.CreatureType.DWARF;
        } else if (input == "Fairy")
        {
            return Creature.CreatureType.FAIRY;
        } else if (input == "Demon")
        {
            return Creature.CreatureType.DEMON;
        } else if (input == "Android")
        {
            return Creature.CreatureType.ANDROID;
        } else if (input == "Beast")
        {
            return Creature.CreatureType.BEAST;
        } else if (input == "Specter")
        {
            return Creature.CreatureType.SPECTER;
        } else if (input == "God")
        {
            return Creature.CreatureType.GOD;
        } else
        {
            return Creature.CreatureType.MAN;
        }
    }

    //helper class to parse JSON string into CreatureClass enum
    private Creature.CreatureClass setClass(string input)
    {
        if (input == "Grunt")
        {
            return Creature.CreatureClass.GRUNT;
        } else if (input == "Warrior")
        {
            return Creature.CreatureClass.WARRIOR;
        } else if (input == "Soldier")
        {
            return Creature.CreatureClass.SOLDIER;
        }
        else if (input == "Paladin")
        {
            return Creature.CreatureClass.PALADIN;
        }
        else if (input == "Cavalry")
        {
            return Creature.CreatureClass.CAVALRY;
        }
        else if (input == "Mage")
        {
            return Creature.CreatureClass.MAGE;
        }
        else if (input == "Rogue")
        {
            return Creature.CreatureClass.ROGUE;
        }
        else if (input == "Assassin")
        {
            return Creature.CreatureClass.ASSASSIN;
        }
        else if (input == "Marksman")
        {
            return Creature.CreatureClass.MARKSMAN;
        }
        else if (input == "Swordsman")
        {
            return Creature.CreatureClass.SWORDSMAN;
        }
        else if (input == "Brute")
        {
            return Creature.CreatureClass.BRUTE;
        } else
        {
            return Creature.CreatureClass.GRUNT;
        }
    }

    private void loadCreatures()
    {
        crtData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Resources/WastelandCreatures.json"));
        for (int i = 0; i < crtData.Count; i++)
        {
            for (int j = 0; j < (int)crtData[i]["qty"]; j++)
            {
                string name = (string)crtData[i]["name"];
                Creature.CreatureType type = setType((string)crtData[i]["type"]);
                Creature.CreatureClass class_ = setClass((string)crtData[i]["class"]);
                int vitality = (int)crtData[i]["vitality"];
                int strength = (int)crtData[i]["strength"];
                int guard = (int)crtData[i]["guard"];
                Effect effect = new NullEffect();
                Creature toAdd = new Creature(name, vitality, strength, guard, type, class_, effect);
            }
        }
    }

    private void loadEnvironments()
    {
        envData = JsonMapper.ToObject(SerializeField.ReadAllText(Application.dataPath + "/Resources/WastelandEnvironments.json"));
        for (int i = 0; i < envData.Count; i++)
        {
            for (int j = 0; j < (int)envData[i]["qty"]; j++) {
                string name = (string)envData[i]["name"];
                Environment.EnvType type = setEnvType((string)envData[i])
            }
        }
    }

    private void loadStructures()
    {

    }

    private void loadSpells()
    {

    }

    public WastelandDeck()
    {
        name = "Wasteland Starter Deck";
        loadCreatures();
        loadEnvironments();
        loadStructures();
        loadSpells();
        Debug.Log("Wasteland Deck 1st constructor called");
    }

    public WastelandDeck(string name, List<Card> e, List<Card> c, List<Card> st, List<Card> sp) : base(name, e, c, st, sp)
    {
        Debug.Log("Wasteland Deck 2nd constructor called");
    }
}
