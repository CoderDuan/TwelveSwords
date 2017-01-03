//普通攻击
//  物理
//  伤害：2d6*atk

using System.Collections;

public class Attack : Skill
{
    public Attack()
    {
        init();
    }

    public override void init()
    {
        type = SkillType.PHYSICAL;
        level = SkillLevel.PRIMARY;
        cost = 0;
        proficient = 0;
        maxProficient = 0;
        constant = 0;
        isLocked = false;
        name = "攻击";
        description = "不管手头有什么，抓起来就是一下";
    }

    public override float[] getProbability(int dice1)
    {
        return null;
    }

    public override int apply(Creature from, Creature to, int dice1, int dice2)
    {
        // 还没有加耗蓝哦
        ArrayList array = new ArrayList();

        int damage = Dice.sum(dice1, dice2) * from.atk;

        damage = to.takeDamage(damage, DamageType.PHYSICAL);

        return damage;
    }
}
