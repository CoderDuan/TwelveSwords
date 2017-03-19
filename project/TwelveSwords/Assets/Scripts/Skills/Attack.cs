//普通攻击
//  物理
//  伤害：2d6*atk

using System.Collections;

public class Attack : Skill
{
    public Attack()
    {
        //init();
    }

    public override float[] getProbability(int dice1)
    {
        return null;
    }

    public override SkillEffectResponse apply(Creature from, Creature to, int dice1, int dice2)
    {
        return null;
    }
}
