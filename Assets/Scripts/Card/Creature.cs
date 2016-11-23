using UnityEngine;
using System.Collections;

public class Creature : Card {
    
    // fields
    protected int vitality;
    protected int strength;
    protected int guard;
    protected Player owner;
    protected int moveInit;
    protected int attackInit;
    protected Zone currentLocation;

    // enums
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

    //for construction
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

    //getters and setters

    //initiative
    public bool canMove()
    {
        return moveInit > 0;
    }

    public void decreaseMoveInit(int i)
    {
        moveInit -= i;
    }

    public void increaseMoveInit(int i)
    {
        moveInit += i;
    }

    public bool canAttack()
    {
        return attackInit > 0;
    }

    public void decreaseAttackInit(int i)
    {
        attackInit -= i;
    }

    public void increaseAttackInit(int i)
    {
        attackInit += i;
    }

    public void setAttackInit()
    {
        attackInit = 1;
    }

    //owner
    public Player getOwner()
    {
        return owner;
    }

    public void setOwner(Player newPlayer)
    {
        owner = newPlayer;
    }

    //location
    public Zone getCurrentLocation()
    {
        return currentLocation;
    }

    public void setCurrentLocation(Zone newZone)
    {
        currentLocation = newZone;
    }

    //vitality
    public int getVitality()
    {
        return vitality;
    }

    public void damage(int i)
    {
        vitality -= i;
        if (vitality < 0)
        {
            vitality = 0;
        }
    }

    public void heal(int i)
    {
        vitality += i;
    }
    
    //guard
    public int getGuard()
    {
        return guard;
    }

    public void decreaseGuard(int i)
    {
        guard -= i;
    }

    public void increaseGuard(int i)
    {
        guard += i;
    }

    //strength
    public int getStrength()
    {
        return strength;
    }

    public void decreaseStrength(int i)
    {
        strength -= i;
    }

    public void increaseStrength(int i)
    {
        strength += i;
    }

    //actions
    public void attack(Creature target)
    {
        if (strength > target.getGuard())
        {
            target.damage(strength - target.getGuard());
        } else if (strength < target.getGuard())
        {
            damage(target.getGuard() - strength);
        }
    }

    public bool isDestroyed()
    {
        return vitality == 0;
    }


    // all-arguments constructor
    public Creature(string name, int vitality, int strength, int guard, CreatureType type, CreatureClass class_, Effect effect)
    {
        this.cardName = name;
        this.cardType = CardType.CREATURE;
        this.vitality = vitality;
        this.strength = strength;
        this.guard = guard;
        this.creatureType = type;
        this.creatureClass = class_;
        creatureAttributes = new CreatureAttribute[2];
        setAttributes();
        this.moveInit = 1;
        this.attackInit = 1;
        this.effect = effect;
    }

    //no-arguments constructor
    public Creature()
    {
        this.cardName = "Card Name";
        this.cardType = CardType.CREATURE;
        this.vitality = 0;
        this.strength = 0;
        this.guard = 0;
        this.creatureType = CreatureType.MAN;
        this.creatureClass = CreatureClass.GRUNT;
        creatureAttributes = new CreatureAttribute[2];
        setAttributes();
        this.moveInit = 1;
        this.attackInit = 1;
        this.effect = new NullEffect();
    }

}
