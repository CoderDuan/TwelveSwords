// 猛砍
// 怪物技能
// 伤害：2d6 * atk
// 	 -精通1：当两次数值相同时，造成200%的伤害。
using System.Collections.Generic;

public class Slash : Skill
{
	public Slash()
	{
		skillId = "mon_skill_slash";
		name = "猛砍";
		damageFormula = "2d6 * atk";
		description = "挥动手中的武器，对敌人进行猛力一击，并且有概率造成更多的伤害。";
		maxProficient = 1;
		proficient = 1;
		proficientInformation = new string[1];
		proficientInformation[0] = "暴击[精通1]：当两次数值相同时，造成200%的伤害";
		proficientName = new string[1];
		proficientName[0] = "暴击[精通1]";
	}

	public override float[] getProbability(int dice1)
	{
		return null;
	}

	public override SkillEffectResponse apply(Creature from, Creature to, int dice1, int dice2)
	{
		SkillEffectResponse response = new SkillEffectResponse();
		response.proficient = new List<bool>();


		return response;
	}
}
