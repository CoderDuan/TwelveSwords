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

    public Creature(string _name, int _hp, int _mp, int _atk, int _def, int _mag)
    {
        name = _name;
        hp = _hp;
        mp = _mp;
        atk = _atk;
        def = _def;
        mag = _mag;
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