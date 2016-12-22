using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Hero hero;
    public Monster monster;
    public SKillScroll scroll;

    public int turn = 0;
    public int dice1 = 1;
    public int dice2 = 1;

    private State state = State.HERO_DICE_1;

    public enum State
    {
        OVER = 0,
        MONSTER_TURN,
        HERO_DICE_1,
        WAIT_SKILL
    }

	// Use this for initialization
	void Start () {
        turn = 0;
        dice1 = 1;
        dice2 = 1;
        hero = new Hero();
        monster = new Orc();
	}
	
	// Update is called once per frame
	void Update () {
        if (state == State.OVER)
        {
            return;
        }
		if (hero.hp == 0 && state != State.OVER)
        {
            state = State.OVER;
            Debug.Log("You lose");
        }
        else if (monster.hp == 0 && state != State.OVER)
        {
            state = State.OVER;
            Debug.Log("You win");
        }
        else
        {
            if (state == State.HERO_DICE_1)
            {
                turn++;
                Debug.Log("------------------------------------------------------");
                Debug.Log(hero.name + "回合" + turn.ToString());

                Debug.Log(hero.name + "血量：" + hero.hp.ToString() + "/" + hero.maxHp.ToString());
                Debug.Log(monster.name + "血量：" + monster.hp.ToString() + "/" + monster.maxHp.ToString());

                dice1 = Random.Range(1, 7);
                Debug.Log(hero.name + " 第一个骰子值 " + dice1.ToString());
                Debug.Log("等待" + hero.name + "选择技能");
                state = State.WAIT_SKILL;
            }
            else if (state == State.MONSTER_TURN)
            {
                dice1 = Random.Range(1, 7);
                dice2 = Random.Range(1, 7);

                Debug.Log(monster.name + " 第一个骰子值 " + dice1.ToString());
                Debug.Log(monster.name + " 第二个骰子值 " + dice2.ToString());

                ArrayList buffArray = monster.takeTurn(hero, dice1, dice2);

                if (buffArray == null)
                    Debug.Log(monster.name + " 并没有行动");
                else
                {
                    Debug.Log(monster.name + " 普通攻击了一下");

                    int size = buffArray.Count;
                    int damageIdx = size - 1;

                    for (int i = 0; i < damageIdx - 1;i++ )
                    {
                        Debug.Log(((Buff)buffArray[i]).name + "+" + ((Buff)buffArray[i]).turn.ToString());

                    }

                    Debug.Log(hero.name + " 受到了 " + ((Buff)buffArray[damageIdx]).extraValue.ToString() + " 伤害");

                    Debug.Log(hero.name + "血量：" + hero.hp.ToString() + "/" + hero.maxHp.ToString());
                    Debug.Log(monster.name + "血量：" + monster.hp.ToString() + "/" + monster.maxHp.ToString());
                }

                state = State.HERO_DICE_1;
            }
        }
	}
    public void castSkill()
    {
        if (state == State.WAIT_SKILL)
        {
            Skill skill = scroll.selectedSkill;
            if (skill == null)
            {
                Debug.Log("没有选择任何法术。");
                return;
            }
            Debug.Log(hero.name + "选择了 " + skill.name + "(" + skill.proficient + "/4)");
            Debug.Log(skill.name + "：" + skill.description);

            dice2 = Random.Range(1, 7);

            Debug.Log(hero.name + " 第二个骰子值 " + dice2.ToString());

            ArrayList buffArray = skill.apply(hero, monster, dice1, dice2);

            int size = buffArray.Count;
            int damageIdx = size - 1;

            for (int i = 0; i < damageIdx - 1;i++ )
            {
                Debug.Log(((Buff)buffArray[i]).name + "+" + ((Buff)buffArray[i]).turn.ToString());

            }

            Debug.Log(monster.name + " 受到了 " + ((Buff)buffArray[damageIdx]).extraValue.ToString() + " 伤害");


            Debug.Log(hero.name + "血量：" + hero.hp.ToString() + "/" + hero.maxHp.ToString());
            Debug.Log(monster.name + "血量：" + monster.hp.ToString() + "/" + monster.maxHp.ToString());

            state = State.MONSTER_TURN;
        }
    }
}
