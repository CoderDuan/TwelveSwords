using System.Collections;
using System.Collections.Generic;

public class Monster : Creature
{
    public uint turn;
    public string description;

    public Monster(string name, int hp, int mp, int atk, int def, int mag)
        : base(name, hp, mp, atk, def, mag)
    {
        
    }

    public void takeTurn()
    {

    }
}
