using System;
using System.Collections.Generic;

public class Creature
{
    public int hp;
    public int maxHp;
    public int mp;
    public int maxMp;
    public int atk;
    public int mag;
    public string name;

    public float damage_increment = 0.0f;
    public float damage_reduction = 1.0f;

    public List<Skill> skillList = new List<Skill>();

    //public List<PassiveSkill> passiveSkillList = new List<PassiveSkill>();
    //public PassiveSkill activePassiveSkill;

    public Creature()
    {

    }

    public virtual void init()
    {

    }

	public void takeDamagePrimary(SkillEffectResponse response)
	{
		int size = response.damage.Count;
		int damageCount = 0;
		response.hp = new List<int> ();
		for (int i=0;i<size;i++)
		{
			response.damage[i] = (int)(response.damage[i] * damage_reduction);
			damageCount += response.damage[i];
			response.hp.Add (hp - damageCount);
		}
		int newhp = hp - damageCount;
		newhp = newhp < 0 ? 0 : newhp;
		hp = newhp;
		response.hp [response.hp.Count - 1] = hp;
	}

    public virtual void takeDamage(SkillEffectResponse response)
    {
        
    }

    public void applyBuff()
    {
        // 处理持续伤害buff
    }

    public void buffTakeTurn()
    {

    }
}