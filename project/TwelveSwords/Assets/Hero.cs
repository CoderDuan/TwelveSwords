using System.Collections;
using System.Collections.Generic;

public class Hero : Creature
{
    public uint exp;
    public uint level;
    public uint proficientPoint = 0;
    public Item[] item = new Item[3];
    public List<Title> titleList = new List<Title>();

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
        def = 5;
        mag = 5;
    }
}
