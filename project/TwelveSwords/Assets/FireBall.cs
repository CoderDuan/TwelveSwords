//火球术 20
//  魔法
//  伤害：max(2d6) * mag + 20
//    -精通1：当第二次数值大于第一次时，伤害增加30%；当第二次数值小于第一次时，耗蓝减少30%；
//    -精通2：当第一次数值为偶数时，对敌人生成3回合的灼烧BUFF。 
//    -精通3：当两次数值奇偶性相同时，对敌人产生3回合的破甲BUFF。
//    -精通4：当两次数值之和大于等于10时，额外发射一枚同效果的火球。
public class FireBall : Skill
{
    public FireBall()
    {
        init();
    }

    public override void init()
    {
        type = SkillType.MAGIC;
        cost = 20;
        proficient = 1;
        constant = 20;
    }

    public override float[] getProbability(int dice1)
    {
        float[] ret = new float[] { 0.0f, 0.0f, 0.0f, 0.0f };

        if (proficient >= 1)
        {
            ret[0] = 5.0f / 6.0f;
        }
        else if (proficient >=2 )
        {
            if (dice1 % 2 == 0)
                ret[1] = 1.0f;
        }
        else if (proficient >= 3)
        {
            ret[2] = 0.5f;
        }
        else if (proficient >= 4)
        {
            if (dice1 == 4)
                ret[3] = 1.0f / 6.0f;
            else if (dice1 == 5)
                ret[3] = 2.0f / 6.0f;
            else if (dice1 == 6)
                ret[3] = 3.0f / 6.0f;
        }

        return ret;
    }

    public override void apply(Creature from, Creature to, int dice1, int dice2)
    {
        int mag = from.mag;

        int damage = Dice.max(dice1, dice2);

        to.takeDamage(damage, DamageType.MAGIC);
    }
 }