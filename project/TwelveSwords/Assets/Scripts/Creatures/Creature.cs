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

	public void takeDamagePrimary(SingleEffectResponse response)
	{
		// when call takeDamage, it means this is the opponent
		if (response.opponent_hp_change < 0) {
			response.opponent_hp_change = (int)(response.opponent_hp_change * damage_reduction);
			int newhp = hp + response.opponent_hp_change;
			newhp = newhp < 0 ? 0 : newhp;
			hp = newhp;
		} 
		else if (response.opponent_hp_change > 0) 
		{
			int newhp = hp + response.opponent_hp_change;
			newhp = newhp > maxHp ? maxHp : newhp;
		}

		if (response.opponent_mp_change != 0) {
			int newmp = mp + response.opponent_mp_change;
			newmp = newmp < 0 ? 0 : newmp;
			newmp = newmp > maxMp ? maxMp : newmp;
			mp = newmp;
		} 
	}

	public virtual CounterEffectResponse takeDamage(SingleEffectResponse response)
    {
		// when call takeDamage, it means that
		// 	1. this is the SkillEffectResponse.opponent
		// 	2. this is the CounterEffectResponse.self
		// and CounterEffectResponse.self will be applied in this function
		return null;
    }

	public virtual void takeCounterEffect(CounterEffectResponse response)
	{
		// when call takeCounterEffect, it means this is the opponent
		if (response.opponent_hp_change < 0) {
			response.opponent_hp_change = (int)(response.opponent_hp_change * damage_reduction);
			int newhp = hp + response.opponent_hp_change;
			newhp = newhp < 0 ? 0 : newhp;
			hp = newhp;
		} 
		else if (response.opponent_hp_change > 0) 
		{
			int newhp = hp + response.opponent_hp_change;
			newhp = newhp > maxHp ? maxHp : newhp;
		}

		if (response.opponent_mp_change != 0) {
			int newmp = mp + response.opponent_mp_change;
			newmp = newmp < 0 ? 0 : newmp;
			newmp = newmp > maxMp ? maxMp : newmp;
			mp = newmp;
		} 
	}

    public void applyBuff()
    {
        // 处理持续伤害buff
    }

    public void buffTakeTurn()
    {

    }
}