using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Hero hero;
    public Monster monster;
    public int turn;

    private State state = State.HEROTURN;

    public enum State
    {
        WIN = 0,
        LOSE,
        MONSTERTURN,
        HEROTURN
    }

	// Use this for initialization
	void Start () {
        hero = new Hero("Duan", 250, 60, 5, 5, 5);
        monster = new Monster("Orc", 250, 0, 5, 5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (hero.hp == 0 && (state != State.LOSE || state != State.WIN))
        {
            state = State.LOSE;
            Debug.Log("You lose");
        }
        else if (monster.hp == 0 && (state != State.LOSE || state != State.WIN))
        {
            state = State.WIN;
            Debug.Log("You win");
        }
        else
        {
            if (state == State.HEROTURN)
            {
                int dice1 = Random.Range(1, 7);



                int dice2 = Random.Range(1, 7);
                
            }
            else if (state == State.MONSTERTURN)
            {
                monster.takeTurn();
            }
        }
	}
}
