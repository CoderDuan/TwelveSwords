using System.Collections;
using System.Collections.Generic;

public class Hero : Creature
{
    public uint exp;
    public uint level;
    public int fury;

    public Item[] equipments = new Item[3];
    public List<Title> titleList = new List<Title>();

    public int melanization;
    public int max_melanization = 100;
    public bool is_melanization = false;
    //public List<FurySkill> furySkillList = new List<FurySkill>();
    //public FurySkill activeFurySkill;

    public Hero()
    {
        init();
    }

    public override void init()
    {
        exp = 0;
        level = 1;

        name = "Lee";
        base_hp = 50;
        base_mp = 10;
        base_atk = 1;
        base_mag = 1;

		creature_id = "hero";

		detail = new DetailInformation ();

		detail.max_hp = base_hp;
		detail.max_mp = base_mp;
		detail.cur_hp = detail.max_hp;
		detail.cur_mp = detail.max_mp;
		detail.final_atk = base_atk;
		detail.final_mag = base_mag;
    }

	public override CounterEffectResponse takeDamage (SingleEffectResponse response)
	{
		takeDamagePrimary (response);
		return null;
	}
}
