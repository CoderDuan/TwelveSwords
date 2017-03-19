using System.Collections;
using System.Collections.Generic;

public class Monster : Creature
{
    public int turn;
    public string monsterId;
    public string description;

    public Monster()
    {
        
    }

    public override void init()
    {

    }

    public virtual int takeTurn(Hero hero, int d1, int d2)
    {
        return -1;
    }
}
