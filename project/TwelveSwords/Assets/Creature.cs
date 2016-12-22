using System;
using System.Collections.Generic;

enum DamageType
{
    PHYSICAL = 0,
    MAGIC,
}

public class Creature
{
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int mag;
    public string name;

    public Creature(string name, int hp, int mp, int atk, int def, int mag)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.def = def;
        this.mag = mag;
    }

    public List<Skill> skillList = new List<Skill>();
    //public List<PassiveSkill> passiveSkillList = new List<PassiveSkill>();
    //public PassiveSkill activePassiveSkill;
    public virtual void takeDamage(int damage, int type) { }

    public void applyBuff()
    {
        // TBD
    }
}