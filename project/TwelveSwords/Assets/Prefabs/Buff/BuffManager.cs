using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour {

	public Buff buff;
	public GameObject obj;
	public Image image;
	public Text count;

	public void setBuff(Buff b)
	{
		buff = b;
		image.sprite = Resources.Load<Sprite> (Global.PREFAB_BUFF_FIGURE_PATH + buff.buffid.ToString());
	}

	public void updateBuff(Buff b)
	{
		if (buff.accumulative)
			buff.turn += b.turn;
		else
			buff.turn = buff.turn > b.turn ? buff.turn : b.turn;
		b = null;
	}

	public void buffTurnChange(int change)
	{
		if (buff == null)
			return;
		buff.turn += change;
		count.text = buff.turn.ToString ();
		if (buff.turn <= 0)
			destroySelf ();
	}

	public void buffTakeTurn()
	{
		if (buff == null)
			return;
		buffTurnChange (-1);
	}

	public void destroySelf()
	{
		buff = null;
		Destroy (obj);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
