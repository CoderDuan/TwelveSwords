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

        name = "Luke";
        hp = 50;
        maxHp = 50;
        mp = 30;
        maxMp = 30;
        atk = 1;
        mag = 1;
    }

	public override CounterEffectResponse takeDamage (SingleEffectResponse response)
	{
		takeDamagePrimary (response);
		return null;
	}
}
