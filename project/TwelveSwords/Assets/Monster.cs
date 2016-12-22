using System.Collections;
using System.Collections.Generic;

public class Monster : Creature
{
    public uint turn;
    public string description;

    public Monster()
    {
        
    }

    public override void init()
    {

    }

    public virtual void takeTurn(Hero hero, int d1, int d2)
    {

    }
}
