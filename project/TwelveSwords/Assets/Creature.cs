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
    public virtual void takeDamage(int damage, int type)
    {
        switch(type)
        {
            case (int)DamageType.PHYSICAL:
                int dmg = damage - def;
                if (dmg < 0)
                    dmg = 0;
                hp -= dmg;
                break;
            case (int)DamageType.MAGICAL:
                hp -= damage;
                break;
            default:
                hp -= damage;
                break;
        }
    }

    public void applyBuff()
    {
        // TBD
    }
}