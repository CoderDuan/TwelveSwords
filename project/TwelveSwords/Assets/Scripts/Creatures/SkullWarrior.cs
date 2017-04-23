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
        name = "Skull Warrior";
		creature_id = "skull_warrior";
        description = "由亡灵之力控制的骷髅战士";

		base_hp = 55;
		base_mp = 0;
		base_atk = 1;
		base_mag = 0;

		detail = new DetailInformation ();

		detail.max_hp = base_hp;
		detail.max_mp = base_mp;
		detail.cur_hp = detail.max_hp;
		detail.cur_mp = detail.max_mp;
		detail.final_atk = base_atk;
		detail.final_mag = base_mag;

        turn = 0;
    }

    void calculateTurn()
    {
        turn++;
    }

	public override CounterEffectResponse takeDamage(SingleEffectResponse response)
	{
		takeDamagePrimary (response);
		if (response.type == SkillType.PHYSICAL && response.stage == response.total - 1) {
			// when it takes counter, it means this is 'self'
			//CounterEffectResponse counter = new CounterEffectResponse ();
			//counter.opponent_hp_change = new List<int> ();
			//counter.opponent_hp_change.Add (atk);
			CounterEffectResponse counter = new CounterEffectResponse();
			counter.opponent_hp_change = -detail.final_atk;
			return counter;
		} else {
			return null;
		}
		//return null;
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
