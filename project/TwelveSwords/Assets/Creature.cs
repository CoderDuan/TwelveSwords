using System;
using System.Collections.Generic;

public enum DamageType
{
    PHYSICAL = 0,
    MAGICAL,
}

public class Creature
{
    public int hp;
    public int maxHp;
    public int mp;
    public int maxMp;
    public int atk;
    public int def;
    public int mag;
    public string name;

    public Creature()
    {

    }

    public virtual void init()
    {

    }

    public List<Skill> skillList = new List<Skill>();
    //public List<PassiveSkill> passiveSkillList = new List<PassiveSkill>();
    //public PassiveSkill activePassiveSkill;
    public virtual int takeDamage(int damage, DamageType type)
    {
        int dmg = damage;
        switch(type)
        {
            case DamageType.PHYSICAL:
                dmg = dmg - def;
                if (dmg < 0)
                    dmg = 0;
                hp -= dmg;
                break;
            case DamageType.MAGICAL:
                hp -= dmg;
                break;
            default:
                hp -= dmg;
                break;
        }
        if (hp < 0) hp = 0;
        return dmg;
    }

    public void applyBuff()
    {
        // TBD
    }
}