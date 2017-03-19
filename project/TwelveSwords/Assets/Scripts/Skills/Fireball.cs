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
        name = "火球术";
		type = DamageType.MAGICAL;
        level = SkillLevel.PRIMARY;
        usable = SkillUsable.UNIVERSAL;
        cost = 1;
        damageFormula = "(max(2d6) + 3) * mag";
        description = "将魔力汇聚到手上，能量汇聚成火球，向目标激射出去，是最基础的法术，学院新生的必修法术。";
        maxProficient = 3;
        proficient = 3;
        isLocked = false;
        proficientInformation = new string[3];
		proficientInformation[0] = "强火[精通1]：当第二次数值大于第一次时，伤害增加50%";
		proficientInformation[1] = "减耗[精通2]：当第二次数值大于第一次两倍时，本次施法不耗蓝";
		proficientInformation[2] = "连环[精通3]：当第二次数值大于第一次三倍时，额外发射一枚同效果的火球";   
		proficientName = new string[3];
		proficientName [0] = "强火[精通1]";
		proficientName [1] = "减耗[精通2]";
		proficientName [2] = "连环[精通3]";
    }

    public override float[] getProbability(int dice1)
    {
        float[] ret = new float[] { 0.0f, 0.0f, 0.0f };

        ret[0] = (proficient >= 1) ? ((float)(6 - dice1)) / 6.0f : 0.0f;
        ret[1] = (proficient >= 2 && dice1 <= 2) ? ((float)(6 - 2 * dice1)) / 6.0f : 0.0f;
        ret[2] = (proficient >= 3 && dice1 == 1) ? 0.5f : 0.0f;
        
        return ret;
    }

    public override SkillEffectResponse apply(Creature from, Creature to, int dice1, int dice2)
    {
		// Calculate damage, buffs
        SkillEffectResponse response = new SkillEffectResponse();
		response.type = type;
        response.damage = new List<int>();
        response.proficient = new List<bool>();
        response.mana = new List<int>();

        float damage = (Dice.max(dice1, dice2) + 3) * from.mag * (1.0f + from.damage_increment);
        int manacost = cost;

        if (proficient >= 1 && dice2 > dice1)
        {
            damage *= 1.5f;
            response.proficient.Add(true);
        }
        else
        {
            response.proficient.Add(false);
        }
        response.damage.Add((int)damage);

        if (proficient >= 2 && dice2 > dice1 * 2)
        {
            manacost = 0;
            response.proficient.Add(true);
        }
        else
        {
            response.proficient.Add(false);
        }

        if (dice2 > dice1 * 3)
        {
            response.damage.Add((int)damage);
            response.proficient.Add(true);
        }
        else
        {
            response.proficient.Add(false);
        }

        response.mana.Add(manacost);

        from.mp -= manacost;
        
		// Apply all effect to target
		to.takeDamage(response);
		// no need to calculate counter attack

        return response;
    }
 }