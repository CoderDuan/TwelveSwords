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
    public int mag;
    public string name;

    public List<Buff> buffList = new List<Buff>();

    public List<Skill> skillList = new List<Skill>();

    //public List<PassiveSkill> passiveSkillList = new List<PassiveSkill>();
    //public PassiveSkill activePassiveSkill;

    public Creature()
    {

    }

    public virtual void init()
    {

    }
    public virtual int takeDamage(int damage, DamageType type)
    {
        // 检查buff列表中是否有增伤或者减伤buff
        int dmg = damage;
        hp -= dmg;
        if (hp < 0) hp = 0;
        return dmg;
    }

    public void applyBuff()
    {
        // 处理持续伤害buff
    }

    public void buffTakeTurn()
    {

    }
}