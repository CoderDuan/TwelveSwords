using System.Collections;
using System.Collections.Generic;

public class Hero : Creature
{
    public uint exp;
    public uint level;
    public uint proficientPoint = 0;
    public Item[] item = new Item[3];
    public List<Title> titleList = new List<Title>();

    public Hero(string name, int hp, int mp, int atk, int def, int mag)
        : base(name, hp, mp, atk, def, mag)
    {

    }
}
