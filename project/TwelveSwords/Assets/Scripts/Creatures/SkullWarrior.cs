using System.Collections;
using System.Collections.Generic;

public class SkullWarrior : Monster
{
    public SkullWarrior()
    {
        init();
    }

    public override void init()
    {
        name = "骷髅战士";
        monsterId = "monster_skullwarrior";
        description = "由亡灵之力控制的骷髅战士";
        hp = 50;
        maxHp = 50;
        atk = 1;
        mag = 0;
        turn = 0;
    }

    void calculateTurn()
    {
        turn++;
    }

	public override void takeDamage(SkillEffectResponse response)
	{
		takeDamagePrimary (response);
		if (response.type == DamageType.PHYSICAL) 
		{
			response.counterattack = new List<int> ();
			response.counterattack.Add (atk);
		}
	}

    public override int takeTurn(Hero hero, int d1, int d2)
    {
        calculateTurn();
        if (turn % 2 == 0)
        {
            
        }
        return 0;
    }
}
