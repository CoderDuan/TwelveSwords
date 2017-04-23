using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureManager : MonoBehaviour {
	private static float BAR_WIDTH = 233.0f;
	private static float BAR_HEIHT = 18.0f;

	public Creature creature;

	public GameObject _dying;
	public Image _image;
	public Text _atk;
	public Text _mag;
	public RectTransform _hp = null;
	public RectTransform _mp = null;
	public Text _hp_txt;
	public Text _mp_txt;
	public Text _hp_max;
	public Text _mp_max;

	public void bindCreature(Creature c)
	{
		creature = c;
		_image.sprite = Resources.Load<Sprite> (Global.PREFAB_IMAGE_FIGURE_PATH + creature.creature_id);
		_atk.text = creature.detail.final_atk.ToString ();
		_mag.text = creature.detail.final_mag.ToString ();

		_hp_txt.text = creature.detail.cur_hp.ToString ();
		_hp_max.text = creature.detail.max_hp.ToString ();
		float p = ((float)creature.detail.cur_hp) / ((float)creature.detail.max_hp);
		_hp.sizeDelta = new Vector2 (p * BAR_WIDTH, BAR_HEIHT);

		if (_mp != null)
		{
			_mp_txt.text = creature.detail.cur_mp.ToString ();
			_mp_max.text = creature.detail.max_mp.ToString ();
			_mp.sizeDelta = new Vector2 (((float)creature.detail.cur_mp) / ((float)creature.detail.max_mp) * BAR_WIDTH, BAR_HEIHT);
		}
	}

	public void UpdateManually()
	{
		_atk.text = creature.detail.final_atk.ToString ();
		_mag.text = creature.detail.final_mag.ToString ();

		_hp_txt.text = creature.detail.cur_hp.ToString ();
		_hp_max.text = creature.detail.max_hp.ToString ();
		float p = ((float)creature.detail.cur_hp) / ((float)creature.detail.max_hp);
		_hp.sizeDelta = new Vector2 (p * BAR_WIDTH, BAR_HEIHT);

		if (_mp != null)
		{
			_mp_txt.text = creature.detail.cur_mp.ToString ();
			_mp_max.text = creature.detail.max_mp.ToString ();
			_mp.sizeDelta = new Vector2 (((float)creature.detail.cur_mp) / ((float)creature.detail.max_mp) * BAR_WIDTH, BAR_HEIHT);
		}

		if (p != 0.0f && p <= 0.1f)
			_dying.SetActive (true);
		else
			_dying.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
