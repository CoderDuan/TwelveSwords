using System.Collections;
using System.Collections.Generic;

public class Orc : Monster
{
    public Orc()
    {
        init();
    }

    public override void init()
    {
        name = "Orc";
        hp = 250;
        maxHp = 250;
        atk = 5;
        mag = 5;
        turn = 0;
    }

    void calculateTurn()
    {
        turn++;
    }

    public override int takeTurn(Hero hero, int d1, int d2)
    {
        
        return 0;
    }
}
