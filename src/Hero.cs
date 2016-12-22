using System.Collections;
using System.Collections.Generic;

public class Hero : Creature
{
    public uint exp;
    public uint level;
    public uint proficientPoint = 0;
    public Item[] item = new Item[3];
    public List<Title> titleList = new List<Title>();

    public Hero(string _name, int _hp, int _mp, int _atk, int _def, int _mag)
        : base(_name, _hp, _mp, _atk, _def, _mag)
    {

    }
}
