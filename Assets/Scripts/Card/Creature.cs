using UnityEngine;
using System.Collections;

public class Creature : Card {
    
    // stat fields
    private int vitality;
    private int strength;
    private int guard;

    private int initiative;

    public enum CreatureType
    {
        MAN,
        ELF,
        DWARF,
        FAIRY,
        DEMON,
        ANDROID,
        BEAST,
        SPECTER,
        GOD
    }

    public enum CreatureClass
    {
        GRUNT,
        WARRIOR,
        SOLDIER,
        PALADIN,
        CAVALRY,
        MAGE,
        ROGUE,
        ASSASSIN,
        MARKSMAN,
        SWORDSMAN,
        BRUTE
    }

    public enum CreatureAttribute
    {
        STUBBORN,
        RUSH,
        PRIDE,
        RALLY,
        PRAYER,
        STAMPEDE,
        FOCUS,
        STEALTH,
        PRECISION,
        KEEN
    }

    private CreatureType creatureType;
    private CreatureClass creatureClass;
    private CreatureAttribute[] creatureAttributes;

    private void setAttributes()
    {
        switch (creatureClass)
        {
            case CreatureClass.GRUNT:
                this.creatureAttributes[0] = CreatureAttribute.STUBBORN;
                break;
            case CreatureClass.WARRIOR:
                this.creatureAttributes[0] = CreatureAttribute.RUSH;
                this.creatureAttributes[1] = CreatureAttribute.PRIDE;
                break;
            case CreatureClass.SOLDIER:
                this.creatureAttributes[0] = CreatureAttribute.RALLY;
                this.creatureAttributes[1] = CreatureAttribute.PRIDE;
                break;
            case CreatureClass.PALADIN:
                this.creatureAttributes[0] = CreatureAttribute.PRAYER;
                this.creatureAttributes[1] = CreatureAttribute.PRIDE;
                break;
            case CreatureClass.CAVALRY:
                this.creatureAttributes[0] = CreatureAttribute.RUSH;
                this.creatureAttributes[1] = CreatureAttribute.STAMPEDE;
                break;
            case CreatureClass.MAGE:
                this.creatureAttributes[0] = CreatureAttribute.PRAYER;
                this.creatureAttributes[1] = CreatureAttribute.FOCUS;
                break;
            case CreatureClass.ROGUE:
                this.creatureAttributes[0] = CreatureAttribute.STEALTH;
                this.creatureAttributes[1] = CreatureAttribute.PRIDE;
                break;
            case CreatureClass.ASSASSIN:
                this.creatureAttributes[0] = CreatureAttribute.STEALTH;
                this.creatureAttributes[1] = CreatureAttribute.PRECISION;
                break;
            case CreatureClass.MARKSMAN:
                this.creatureAttributes[0] = CreatureAttribute.PRECISION;
                this.creatureAttributes[1] = CreatureAttribute.KEEN;
                break;
            case CreatureClass.SWORDSMAN:
                this.creatureAttributes[0] = CreatureAttribute.KEEN;
                this.creatureAttributes[1] = CreatureAttribute.FOCUS;
                break;
            case CreatureClass.BRUTE:
                this.creatureAttributes[0] = CreatureAttribute.RALLY;
                this.creatureAttributes[1] = CreatureAttribute.STAMPEDE;
                break;
            default:
                break;
        }
    }

    public bool hasInitiative()
    {
        return initiative > 0;
    }

    public void useInitiative()
    {
        initiative--;
    }

    public Creature(string name, int vitality, int strength, int guard, CreatureType type, CreatureClass class_)
    {
        setCardName(name);
        setCardType(CardType.CREATURE);
        this.vitality = vitality;
        this.strength = strength;
        this.guard = guard;
        this.creatureType = type;
        this.creatureClass = class_;
        creatureAttributes = new CreatureAttribute[2];
        setAttributes();
        this.initiative = 1;    
    }

}
