﻿  //火球术 1
  //魔法
  //伤害：(max(2d6) + 3) * mag
  //  -精通1：当第二次数值大于第一次时，伤害增加50%；
  //  -精通2：当第二次数值大于第一次两倍时，本次施法不耗蓝；
  //  -精通3：当第二次数值大于第一次三倍时，额外发射一枚同效果的火球。

using System.Collections.Generic;

public class Fireball : Skill
{
    public Fireball()
    {
        skillId = "skill_fireball";
		//prefabPath = "Prefab/Fireball/fireball_prefab";
		preparePath = "Prefab/Fireball/fireball_prepare";
        name = "火球术";
		type = SkillType.PHYSICAL;
        level = SkillLevel.PRIMARY;
        usable = SkillUsable.UNIVERSAL;
        cost = 1;
        damageFormula = "(max(2d6) + 3) * mag";
        description = "将魔力汇聚到手上，能量汇聚成火球，向目标激射出去，是最基础的法术，学院新生的必修法术。";
        maxProficient = 3;
        proficient = 3;
        isLocked = false;
		proficientEffect = new string[3];
		proficientEffect[0] = "- 伤害增加50%";
		proficientEffect[1] = "- 本次施法不耗蓝";
		proficientEffect[2] = "- 额外发射一枚同效果的火球";
		proficientName = new string[3];
		proficientName [0] = "强火[精通1]";
		proficientName [1] = "减耗[精通2]";
		proficientName [2] = "连环[精通3]";
		proficientCondition = new string[3];
		proficientCondition [0] = "：[D1<D2]";
		proficientCondition [1] = "：[2*D1<D2]";
		proficientCondition [2] = "：[3*D1<D2]";
    }

    public override float[] getProbability(int dice1)
    {
        float[] ret = new float[] { 0.0f, 0.0f, 0.0f };

        ret[0] = (proficient >= 1) ? ((float)(6 - dice1)) / 6.0f : 0.0f;
        ret[1] = (proficient >= 2 && dice1 <= 2) ? ((float)(6 - 2 * dice1)) / 6.0f : 0.0f;
        ret[2] = (proficient >= 3 && dice1 == 1) ? 0.5f : 0.0f;
        
        return ret;
    }

    public override SkillEffectResponse apply(Creature from, int dice1, int dice2)
    {
		// Calculate damage, and apply buffs
        SkillEffectResponse response = new SkillEffectResponse();
		//response.type = type;
		//response.color = MyColor.FireballColor;
		response.proficient = new List<int>();

		// change: + means recovery, - means damage/cost
		response.effects = new List<SingleEffectResponse>();
		response.effects.Add (new SingleEffectResponse ());
		response.effects [0].stage = 0;
		response.effects [0].total = 1;
		response.effects [0].type = type;
		response.effects [0].delay = 0.2f;
		response.effects [0].prefabPath = "Prefab/Fireball/fireball_prefab";
//		response.effects [0].opponent_buff_on = new List<Buff> ();
//		response.effects [0].opponent_buff_on.Add (new BuffAmplifyDamage ());
//		response.effects [0].opponent_buff_on.Add (new BuffAmplifyDamage ());
		//response.opponent_hp_change = new List<int>();
		//response.self_mp_change = new List<int>();

		float damage = - (Dice.max(dice1, dice2) + 3) * from.detail.final_mag * from.detail.do_damage_total * from.detail.do_damage_magical;
		int manacost = - (int)((float)cost * from.detail.cost_coefficient);

        if (proficient >= 1 && dice2 > dice1)
        {
            damage *= 1.5f;
            response.proficient.Add(0);
        }

		//response.opponent_hp_change.Add((int)damage);
		response.effects[0].opponent_hp_change = ((int)damage);

        if (proficient >= 2 && dice2 > dice1 * 2)
        {
            manacost = 0;
            response.proficient.Add(1);
        }

		response.effects [0].self_mp_change = manacost;

        if (dice2 > dice1 * 3)
		{
			response.effects [0].total++;
			response.effects.Add (new SingleEffectResponse (response.effects[0]));
            response.proficient.Add(2);
        }

		//response.self_mp_change.Add(manacost);

		from.detail.cur_mp += manacost;
        
		// Apply all effect to target
		//to.takeDamage(response);
		// no need to calculate counter attack

        return response;
    }
 }