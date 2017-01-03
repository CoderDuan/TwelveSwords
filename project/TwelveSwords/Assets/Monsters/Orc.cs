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
        calculateTurn();
        if(turn % 2 == 0)
        {
            int damage = ((d1 + d2) * atk);
            damage = hero.takeDamage(damage, (int)DamageType.PHYSICAL);

            ArrayList array = new ArrayList();

            return damage;
        }
        return 0;
    }
}
