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

        name = "段景耀";
        hp = 50;
        maxHp = 50;
        mp = 30;
        maxMp = 30;
        atk = 1;
        mag = 1;
    }

	public void takeCounterAttack(SkillEffectResponse response)
	{
		if (response.counterattack == null)
			return;
		int size = response.counterattack.Count;
		int damageCount = 0;
		response.counterhp = new List<int> ();
		for (int i=0;i<size;i++)
		{
			damageCount += response.counterattack[i];
			response.counterhp.Add (hp - damageCount);
		}
		int newhp = hp - damageCount;
		newhp = newhp < 0 ? 0 : newhp;
		hp = newhp;
		response.counterhp [response.counterhp.Count - 1] = hp;
	}

	public override void takeDamage (SkillEffectResponse response)
	{
		takeDamagePrimary (response);
	}
}
