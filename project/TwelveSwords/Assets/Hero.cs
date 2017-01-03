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

    private void init()
    {
        exp = 0;
        level = 1;

        name = "段景耀";
        hp = 250;
        maxHp = 250;
        mp = 60;
        maxMp = 60;
        atk = 5;
        mag = 5;
    }
}
