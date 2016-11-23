using UnityEngine;
using System.Collections;

public class Environment : Card {

    public enum EnvType
    {
        JUNGLE,
        MOUNTAIN,
        TUNDRA,
        PLAINS,
        OCEAN,
        DESERT,
        SWAMP,
        CITY,
        WASTELAND
    }

    protected EnvType envType;

    public int lifebloodBonus()
    {
        //TODO: make lifeblood bonuses specifically for each environment type
        return 10;
    }

    public int manaBonus()
    {
        //TODO: make mana bonuses specifically for each environment type;
        return 5;
    }

    public Environment(string name, EnvType et)
    {
        setCardName(name);
        setCardType(CardType.ENVIRONMENT);
        this.envType = et;
    }

    public Environment()
    {
        setCardName("");
        setCardType(CardType.ENVIRONMENT);
        this.envType = EnvType.CITY;
    }
}
