using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class Controller : MonoBehaviour {

	// canvas
	public GameObject canvas;

    public Hero hero;
    public Monster monster;

    // about skill
    public SKillScroll scroll;
    private SkillEffectResponse response = null;
	private CounterEffectResponse counter = null;

    public GameObject dice1_obj;
    public GameObject dice2_obj;

    public int dice1 = 1;
    public int dice2 = 1;
	private Vector2 dice1_pos = new Vector2 (-140.0f, 140.0f);
	private Vector2 dice2_pos = new Vector2 (140.0f, 140.0f);

    private Turn turnState = Turn.HERO;
    private State state = State.DEFEATED;

    // hero and monster visual things
    public GameObject hero_obj;
    public Text hero_max_hp;
    public Text hero_hp;
    public RectTransform hero_hp_bar;
    public Text hero_max_mp;
    public Text hero_mp;
    public RectTransform hero_mp_bar;
    public Text hero_atk;
    public Text hero_mag;
    public GameObject monster_obj;
    public Text monster_max_hp;
    public Text monster_hp;
    public RectTransform monster_bar;
    public Text monster_atk;
    public Text monster_mag;

	// Float text
	public GameObject left_prefab;
	public GameObject right_prefab;
	public GameObject scrolling_text;

	// Attacking
	public GameObject blink_attack;

	// turn counter
	public Text heroTurn;
	public Text monsterTurn;
	public int Hturn = 0;
	public int Mturn = 0;

    public enum Turn
    {
        MONSTER = 0,
        HERO
    }

    public enum State
    {
        VICTORY = 0,
        DEFEATED,
//
//		// Vision 1
//		// State flow
//        PREPARE_BEFROE_START_ANI,
//        ING_BEFROE_START_ANI,
//
//        PREPARE_BUFF_EFFECT_ANI,
//        ING_BUFF_EFFECT_ANI,
//        BUFF_EFFECT_JUDEMENT,
//
//        //END_BUFF_EFFECT_ANI,
//        PREPARE_DICE_1_ANI, // DICE_1 random
//        ING_DICE_1_ANI,
//
//        SELECT_SKILL, // PREPARE_SKILL_SELECT_ANI
//        ING_SELECT_SKILL_ANI,
//
//        PREPARE_DICE_2_ANI, // DICE_1 random
//        ING_DICE_2_ANI,
//
//        // APPLY SKILLS
//        PREPARE_SKILL_ANI, // APPLY SKILL
//        ING_SKILL_ANI,
//        REMOVE_BUFF,
//        PREPARE_DAMAGE_ANI,
//        ING_DAMAGE_ANI,
//        ADD_BUFF,
//
//        JUDGEMENT,
//        BUFF_COUNT,
//
//        PREPARE_TURN_END_ANI,
//        ING_TURN_END_ANI,

		// Vision 2 
		// State flow
		STATE_WAIT,

		STATE_DICE_1,
		STATE_SKILL,
		STATE_SKILL_APPLY,
		STATE_DICE_2,
		STATE_PROFICIENT,
		STATE_SKILL_ANI,
		//STATE_EFFECT,
		//STATE_COUNTER,
		//STATE_COUNTER_EFFECT
		STATE_JUDGEMENT
    }

	public void setState(State s)
	{
		state = s;
	}

//    public void AsyncUpdateState()
//    {
//        switch(state)
//        {
//            case State.ING_DICE_1_ANI:
//            {
//                state = State.SELECT_SKILL;
//                return;
//            }
//            case State.ING_DICE_2_ANI:
//            {
//                state = State.PREPARE_SKILL_ANI;
//                return;
//            }
//            case State.SELECT_SKILL:
//            {
//                state = State.ING_SELECT_SKILL_ANI;
//                return;
//            }
//        }
//    }

    public void NewBattle(Monster new_monster)
    {
        monster = new_monster;

        // init visual 
        // hero and monster
        ((Image)(hero_obj.transform.Find("FIGURE_IMG").gameObject.GetComponent<Image>())).sprite = Resources.Load<Sprite>("hero");
        hero_max_hp.text = hero.maxHp.ToString();
        hero_max_mp.text = hero.maxMp.ToString();
        hero_hp.text = hero.hp.ToString();
        hero_mp.text = hero.mp.ToString();
        float h = hero_hp_bar.sizeDelta.y;
        hero_hp_bar.sizeDelta = new Vector2(((float)hero.hp) / ((float)hero.maxHp) * 233.0f, h);
        hero_mp_bar.sizeDelta = new Vector2(((float)hero.mp) / ((float)hero.maxMp) * 233.0f, h);
        hero_atk.text = hero.atk.ToString();
        hero_mag.text = hero.mag.ToString();

        ((Image)(monster_obj.transform.Find("FIGURE_IMG").gameObject.GetComponent<Image>())).sprite = Resources.Load<Sprite>(monster.monsterId);
        monster_max_hp.text = monster.maxHp.ToString();
        monster_hp.text = monster.hp.ToString();
        h = monster_bar.sizeDelta.y;
        monster_bar.sizeDelta = new Vector2(((float)monster.hp) / ((float)monster.maxHp) * 233.0f, h);
        monster_atk.text = monster.atk.ToString();
        monster_mag.text = monster.mag.ToString();
    }

	// scrolling text
	public void createScrollingText(Vector2 pos, string contents, Color color, float delay, float duration, Controller c, State s)
	{
		GameObject scrollingTextObj = Instantiate (scrolling_text, canvas.transform);
		scrollingTextObj.GetComponent<RectTransform> ().anchoredPosition = pos;
		Text text = scrollingTextObj.GetComponent<Text> ();
		text.text = contents;
		text.color = color;
		ScrollingText scrollingText = scrollingTextObj.GetComponent<ScrollingText> ();
		scrollingText.delay = delay;
		scrollingText.setDuration (duration);
		scrollingText.controller = c;
		scrollingText.state = s;

		scrollingTextObj = null;
		scrollingText = null;
		text = null;
	}

	public void delayCreateFloatingText (bool is_left, string contents, Color color, float seconds)
	{
		StartCoroutine(DelayToInvoke.DelayToInvokeDo(
			()=>{
				GameObject ft = is_left ? Instantiate (left_prefab, canvas.transform) : Instantiate (right_prefab, canvas.transform);
				Text txt = ((Text)ft.GetComponent<Text>());
				txt.text = contents;
				txt.color = color;
			}, seconds));
	}

	public void delayCreateBlinkAttack (Color color, Vector2 pos, float rotation, float seconds)
	{
		StartCoroutine(DelayToInvoke.DelayToInvokeDo(
			()=>{
				GameObject ba = Instantiate (blink_attack, canvas.transform);
				RectTransform trans = ba.GetComponent<RectTransform>();
				trans.anchoredPosition = pos;
				trans.Rotate(0.0f, 0.0f, rotation);
				Image im = ba.GetComponent<Image>();
				im.color = color;
			}, seconds));
	}

	public void delayCreateBlinkAttack (Color color, bool left, float seconds)
	{
		float x = left ? -475.0f : 475.0f;
		Vector2 pos = new Vector2 (x, 160.0f + Random.Range (-10, 11));
		float rotation = Random.Range (-7.0f, 7.0f);
		StartCoroutine(DelayToInvoke.DelayToInvokeDo(
			()=>{
				GameObject ba = Instantiate (blink_attack, canvas.transform);
				RectTransform trans = ba.GetComponent<RectTransform>();
				trans.anchoredPosition = pos;
				trans.Rotate(0.0f, 0.0f, rotation);
				Image im = ba.GetComponent<Image>();
				im.color = color;
			}, seconds));
	}

	public void delayHPMPDecrease (RectTransform rect, Text text, int hp, int maxhp, float seconds)
	{
		StartCoroutine(DelayToInvoke.DelayToInvokeDo(
			()=>{
				rect.sizeDelta = new Vector2(((float)hp) / ((float)maxhp) * 233.0f, 18.0f);
				text.text = hp.ToString();
			}, seconds));
	}

	// Animation Display Functions

	// 显示精通弹出文本，is_left表示是否显示在左边，也就是英雄位置
	// 返回总共delay的时间
	public float displayProficientTexts(bool is_left)
	{
		if (response.proficient != null && response.proficient.Count != 0) {
			float x = is_left ? -467.5f : 467.5f;
			float delay = 0.0f;
			Vector2 pos = new Vector2 (x, 0);
			int size = response.proficient.Count - 1;
			int idx;
			for (int i = 0; i < size; i++) {
				idx = response.proficient [i];
				createScrollingText (pos, scroll.selectedSkill.proficientName [idx], MyColor.ProficientColor [idx],
					delay, 2.4f, null, state);
				delay += 0.4f;
			}
			idx = response.proficient [size];
			// dont forget state
			createScrollingText (pos, scroll.selectedSkill.proficientName [idx], MyColor.ProficientColor [idx],
				delay, 2.4f, null, state/*State.STATE_SKILL_ANI*/);
			delay += 0.4f;

			return delay;
		}
		return 0.0f;
	}

	public float displaySkillEffect(bool is_left)
	{
		if (response.proficient != null) 
		{
			float x = is_left ? -467.5f : 467.5f;
			float delay = 0.0f;
			Vector2 pos = new Vector2 (x, 0);
			int size = response.proficient.Count - 1;
			int idx;
			for (int i = 0; i < size; i++) 
			{
				idx = response.proficient [i];
				createScrollingText (pos, scroll.selectedSkill.proficientName [idx], MyColor.ProficientColor [idx],
					delay, 2.4f, null, state);
				delay += 0.4f;
			}
			idx = response.proficient [size];
			// dont forget state
			createScrollingText (pos, scroll.selectedSkill.proficientName [idx], MyColor.ProficientColor [idx],
				delay, 2.4f, this, State.STATE_SKILL_ANI);
			delay += 0.4f;

			return delay;
		}
		return 0.0f;
	}

	public float generateSkillEffect()
	{
		float delay = 0.0f;
		for (int i = 0; i < response.effects.Count; i++) 
		{
			StartCoroutine(DelayToInvoke.DelayToInvokeDo(
				()=>{
					GameObject effect_prefab = Resources.Load<GameObject> (scroll.selectedSkill.prefabPath);
					GameObject traj = Instantiate (effect_prefab,canvas.transform);
					traj.GetComponent<Identity>().stage = i;
					traj = null;
					effect_prefab = null;
				}, delay));
			delay += 0.2f;
		}
		return delay;
	}

	// When recieve a SingleEffectResponse
	public void recieveEffectResponse(int stage)
	{
		Creature self, opponent;
		if (turnState == Turn.HERO) 
		{
			self = hero;
			opponent = monster;
		}
		else
		{
			self = monster;
			opponent = hero;
		}

		if (stage == response.effects.Count - 1)
			state = State.STATE_JUDGEMENT;

		self = null;
		opponent = null;
	}

	// Use this for initialization
	void Start () {
		Hturn = 0;
        Mturn = 0;
        dice1 = 1;
        dice2 = 1;
		dice1_obj.GetComponent<DiceRoll> ().state = State.STATE_SKILL;
		dice2_obj.GetComponent<DiceRoll> ().state = State.STATE_PROFICIENT;

        turnState = Turn.HERO;
		state = State.STATE_DICE_1;//State.STATE_WAIT;
		//Debug.Log();
		int seed = (int)(long.Parse(System.DateTime.Now.ToString ("yyyyMMddHHmmssfff")) % int.MaxValue);
		Random.InitState (seed);	

        hero = ((HeroContainer)GameObject.Find("Hero").transform.GetComponent<HeroContainer>()).hero;
        //monster = new Orc();
        NewBattle(new SkullWarrior());
	}
	
	// Update is called once per frame
	void Update () {
        switch (turnState)
        {
            case Turn.HERO:
            {
                switch (state)
                {
                    case State.VICTORY:
                    {
                        return;
                    }
                    case State.DEFEATED:
                    {
                        return;
                    }
					case State.STATE_DICE_1:
                    {
                        // random dice 1
                        // init animation and play
						// random a value
						dice1 = Random.Range(1, 7);
                        // reset position
                        dice1_obj.GetComponent<RectTransform>().anchoredPosition = dice1_pos + new Vector2(Random.Range(-30, 31), Random.Range(-30, 31));
                        // set active
                        dice1_obj.SetActive(true);
                        // set value
                        dice1_obj.GetComponent<DiceRoll>().diceValue = dice1;
                        // play animation
                        dice1_obj.GetComponent<Animation>().Play("Dice");

						// turn +1
						Hturn++;
						heroTurn.text = "HTurn : " + Hturn.ToString ();	

						state = State.STATE_WAIT;
                        return;
                    }
					case State.STATE_SKILL:
                    {
                        // do nothing
                        // player select skill in gui

						state = State.STATE_WAIT;
                        return;
                    }
					case State.STATE_SKILL_APPLY:
                    {
                        // do nothing
                        // (later) animation finish event will call 
						//delayCreateFloatingText(true, scroll.selectedSkill.name, MyColor.SkillColor, 0.1f);
						createScrollingText (new Vector2 (-467.5f, 0.0f), scroll.selectedSkill.name, MyColor.SkillColor
							, 0.1f, 0.6f, this, State.STATE_DICE_2);

                        state = State.STATE_WAIT;
                        return;
                    }
					case State.STATE_DICE_2:
                    {
                        // random dice 2
                        // init animation and play
                        // random a value
                        dice2 = Random.Range(1, 7);
                        // reset position
						dice2_obj.GetComponent<RectTransform>().anchoredPosition = dice2_pos + new Vector2(Random.Range(-30, 31), Random.Range(-30, 31));
                        // set active
                        dice2_obj.SetActive(true);
                        // set value
                        dice2_obj.GetComponent<DiceRoll>().diceValue = dice2;
                        // play animation
                        dice2_obj.GetComponent<Animation>().Play("Dice");

                        // apply skill
                        response = scroll.selectedSkill.apply(hero, dice1, dice2);
						// opponent take damage
						//counter = monster.takeDamage(response);
						// apply counter
						//hero.takeCounterEffect(counter);
						// till now, response and counter are ready to display

						// 显示精通文本
						//displayProficientTexts (true);

						// change hp and mp in gui
						//hero_mp.text = hero.mp.ToString();
						//float h = hero_hp_bar.sizeDelta.y;
						//hero_mp_bar.sizeDelta = new Vector2(((float)hero.mp) / ((float)hero.maxMp) * 233.0f, h);

						state = State.STATE_WAIT;
                        return;
                    }
					case State.STATE_PROFICIENT:
                    {
						float delay = displayProficientTexts(true);
						//if (delay == 0.0f)
							state = State.STATE_SKILL_ANI;
						//else
							//state = State.STATE_WAIT;
                        return;
                    }
					case State.STATE_SKILL_ANI:
                    {
						// change hp and mp in gui
						hero_mp.text = hero.mp.ToString();
						float h = hero_hp_bar.sizeDelta.y;
						hero_mp_bar.sizeDelta = new Vector2(((float)hero.mp) / ((float)hero.maxMp) * 233.0f, h);

						generateSkillEffect ();
						
						//effect_prefab = null;

						state = State.STATE_WAIT;
						//state = State.STATE_EFFECT;
                        return;
                    }
					case State.STATE_JUDGEMENT:
                    {
						Debug.Log ("JUDGEMENT");

						state = State.STATE_WAIT;
                        return;
                    }
//                    case State.ADD_BUFF:
//                    {
//                        // add some buff according to skilleffectresponse
//
//                        state = State.PREPARE_DAMAGE_ANI;
//                        return;
//                    }
//                    case State.PREPARE_DAMAGE_ANI:
//                    {
//						float time = 0.1f;
//                        // init animation with damage and play
//						for (int i=0;i<response.damage.Count;i++)
//						{
//							time += i * 0.12f;
//							// blink attack
//							delayCreateBlinkAttack(MyColor.FireballColor, false, time);
//
//							// damage floating text
//							delayCreateFloatingText(false, "-"+response.damage[i].ToString(), MyColor.HpColor, time);
//
//							// target shaking
//							monster_obj.GetComponent<Animation>().Play("Shake");
//
//							// hp decrease
//							delayHPMPDecrease(monster_bar, monster_hp, response.hp[i], monster.maxHp, time);
//						}
//
//						// counterattack
//						if (response.counterattack != null) {
//							for (int i = 0; i < response.counterattack.Count; i++) {
//								time += (i + 1) * 0.12f;
//								// blink counterattack
//								delayCreateBlinkAttack (MyColor.CounterAttackColor, true, time);
//
//								// counterattack floating text
//								delayCreateFloatingText (true, "-" + response.counterattack [i].ToString (), MyColor.HpColor, time);
//
//								// target shaking
//								hero_obj.GetComponent<Animation> ().Play ("Shake");
//
//								// hp decrease
//								delayHPMPDecrease (hero_hp_bar, hero_hp, response.counterhp [i], hero.maxHp, time);
//							}
//						}
//
//						StartCoroutine(DelayToInvoke.DelayToInvokeDo(
//							()=>{
//								state = State.JUDGEMENT;
//							}, time + 0.15f));
//
//                        state = State.ING_DAMAGE_ANI;
//                        return;
//                    }
//                    case State.ING_DAMAGE_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//                        //state = State.JUDGEMENT;
//                        return;
//                    }
//                    case State.JUDGEMENT:
//                    {
//                        // before judge
//                       
//                        // judge if some one win
//
//                        state = State.BUFF_COUNT;
//                        return;
//                    }
//                    case State.BUFF_COUNT:
//                    {
//						// all turns of buff minus 1 
//
//                        state = State.PREPARE_TURN_END_ANI;
//                        return;
//                    }
//                    case State.PREPARE_TURN_END_ANI:
//                    {
//						// prepare turn ending animation and play
//
//                        state = State.ING_TURN_END_ANI;
//                        return;
//                    }
//                    case State.ING_TURN_END_ANI:
//                    {
//                        // do nothing
//						// animation finish event will call 
//
//                        // new turn with monster
//                        turnState = Turn.MONSTER;
//						state = State.PREPARE_BEFROE_START_ANI;
//                        return;
//                    }
                }
				break;
            }
            case Turn.MONSTER :
            {
                switch (state)
                {
                    case State.VICTORY:
                    {
                        return;
                    }
                    case State.DEFEATED:
                    {
                        return;
                    }
//                    case State.PREPARE_BEFROE_START_ANI:
//                    {
//                        // before battle start
//						// init animation and play
//
//                        state = State.ING_BEFROE_START_ANI;
//                        return;
//                    }
//                    case State.ING_BEFROE_START_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//
//                        state = State.PREPARE_BUFF_EFFECT_ANI;
//                        return;
//                    }
//                    case State.PREPARE_BUFF_EFFECT_ANI:
//                    {
//                        // calculate the damage of continuous BUFF
//                        // init animation and play
//
//                        state = State.ING_BUFF_EFFECT_ANI;
//                        return;
//                    }
//                    case State.ING_BUFF_EFFECT_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//						state = State.BUFF_EFFECT_JUDEMENT;
//                        return;
//                    }
//                    case State.BUFF_EFFECT_JUDEMENT:
//                    {
//                        // judge if some one win
//
//                        state = State.PREPARE_DICE_1_ANI;
//                        return;
//                    }
//                    case State.PREPARE_DICE_1_ANI:
//                    {
//                        // random dice 1
//						// init animation and play
//						Mturn++;
//						monsterTurn.text = Mturn.ToString() + " : MTurn";
//
//                        state = State.ING_DICE_1_ANI;
//                        return;
//                    }
//                    case State.ING_DICE_1_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//						state = State.SELECT_SKILL;
//                        return;
//                    }
//                    case State.SELECT_SKILL:
//                    {
//                        // choose which skill to use
//                        // according to turn
//
//                        state = State.ING_SELECT_SKILL_ANI;
//                        return;
//                    }
//                    case State.ING_SELECT_SKILL_ANI:
//                    {
//                        // do nothing
//                        // (later) animation finish event will call 
//
//                        state = State.PREPARE_DICE_2_ANI;
//                        return;
//                    }
//                    case State.PREPARE_DICE_2_ANI:
//                    {
//                        // random dice 2
//                        // init animation and play
//
//                        state = State.ING_DICE_2_ANI;
//                        return;
//                    }
//                    case State.ING_DICE_2_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//						state = State.PREPARE_SKILL_ANI;
//                        return;
//                    }
//                    case State.PREPARE_SKILL_ANI:
//                    {
//                        // init skill animation and play
//
//                        state = State.ING_SKILL_ANI;
//                        return;
//                    }
//                    case State.ING_SKILL_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//						state = State.REMOVE_BUFF;
//                        return;
//                    }
//                    case State.REMOVE_BUFF:
//                    {
//                        // remove some buff according to skill
//
//                        state = State.ADD_BUFF;
//                        return;
//                    }
//                    case State.ADD_BUFF:
//                    {
//                        // add some buff according to skill
//
//                        state = State.PREPARE_DAMAGE_ANI;
//                        return;
//                    }
//                    case State.PREPARE_DAMAGE_ANI:
//                    {
//                        // init animation with damage and play
//
//                        state = State.ING_DAMAGE_ANI;
//                        return;
//                    }
//                    case State.ING_DAMAGE_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//                        state = State.JUDGEMENT;
//                        return;
//                    }
//                    case State.JUDGEMENT:
//                    {
//                        // judge if some one win
//
//                        state = State.BUFF_COUNT;
//                        return;
//                    }
//                    case State.BUFF_COUNT:
//                    {
//                        // all turns of buff minus 1 
//
//                        state = State.PREPARE_TURN_END_ANI;
//
//						// for test
//						StartCoroutine(DelayToInvoke.DelayToInvokeDo(
//							()=>{
//								state = State.ING_TURN_END_ANI;
//							}, 1.85f));
//						
//                        return;
//                    }
//                    case State.PREPARE_TURN_END_ANI:
//                    {
//                        // prepare turn ending animation and play
//
//                        //state = State.ING_TURN_END_ANI;
//                        return;
//                    }
//                    case State.ING_TURN_END_ANI:
//                    {
//                        // do nothing
//                        // animation finish event will call 
//
//						// clean all stage
//						dice1_obj.SetActive(false);
//						dice2_obj.SetActive (false);
//						//scroll.selectedSkill = null;
//                        // new turn with hero
//                        turnState = Turn.HERO;
//                        state = State.PREPARE_BUFF_EFFECT_ANI;
//                        return;
//                    }
                }
				break;
            }
        }
	}
}
