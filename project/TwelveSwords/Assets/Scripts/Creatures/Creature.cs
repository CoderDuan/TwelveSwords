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

	// 对对手造成的伤害系数
	// 对魔法伤害： final_damage = damage * apply_damage_coefficient * apply_magical_coefficient
	public float apply_damage_coefficient = 1.0f; // 所有加在这里的伤害都是叠加
	public float apply_magical_coefficient = 1.0f;
	public float apply_physical_coefficient = 1.0f;

	// 对手对自己造成的伤害系数
	// 对魔法伤害：final_damage = damage * take_magical_coefficient * take_damage_coefficient
	// 反伤只会受 take_damage_coefficient 影响
	public float take_damage_coefficient = 1.0f;
	public float take_magical_coefficient = 1.0f;
	public float take_physical_coefficient = 1.0f;

	// 减耗系数
	public float cost_coefficient = 1.0f;

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
			if (response.type == SkillType.PHYSICAL)
				response.opponent_hp_change = (int)(response.opponent_hp_change * take_damage_coefficient * take_physical_coefficient);
			if (response.type == SkillType.MAGICAL)
				response.opponent_hp_change = (int)(response.opponent_hp_change * take_damage_coefficient * take_magical_coefficient);
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
			response.opponent_hp_change = (int)(response.opponent_hp_change * take_damage_coefficient);
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