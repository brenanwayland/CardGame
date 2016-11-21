using UnityEngine;
using System.Collections;

public class Creature : Card {
    
    // stat fields
    protected int vitality;
    protected int strength;
    protected int guard;

    private int initiative;

    override
    public void effect()
    {

    }

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

    protected CreatureType creatureType;
    protected CreatureClass creatureClass;
    protected CreatureAttribute[] creatureAttributes;

    protected void setAttributes()
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

    // all-arguments constructor
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

    //no-arguments constructor
    public Creature()
    {
        setCardName("Card Name");
        setCardType(CardType.CREATURE);
        this.vitality = 0;
        this.strength = 0;
        this.guard = 0;
        this.creatureType = CreatureType.MAN;
        this.creatureClass = CreatureClass.GRUNT;
        creatureAttributes = new CreatureAttribute[2];
        setAttributes();
        this.initiative = 1;
    }

    public int getVitality()
    {
        return vitality;
    }

}
