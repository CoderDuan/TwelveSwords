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
        def = 5;
        mag = 5;
    }

    void calculateTurn()
    {
        turn++;
    }

    public override void takeTurn(Hero hero, int d1, int d2)
    {
        calculateTurn();
        if(turn % 2 == 0)
        {
            int damage = ((d1 + d2) * atk);
            hero.takeDamage(damage, (int)DamageType.PHYSICAL);
        }
    }
}
