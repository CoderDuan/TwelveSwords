using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffListManager : MonoBehaviour {

	public GameObject list;
	public GameObject cellPrefab;
	public Creature creature;

	public void addBuffs(List<Buff> buffs)
	{
		if (buffs == null)
			return;
		int size = buffs.Count;
		for (int i = 0; i < size; i++) 
			addBuff (buffs [i]);
		//buffs.Clear ();
		buffs = null;
	}

	public void addBuff(Buff buff)
	{
		if (buff.unique)
		{
			Transform buffCell = list.transform.Find (buff.buffid.ToString ());
			if (buffCell == null) 
			{
				GameObject cell = Instantiate (cellPrefab, list.transform);
				cell.GetComponent<BuffManager> ().setBuff (buff);
				cell.name = buff.buffid.ToString ();
			} 
			else
				buffCell.gameObject.GetComponent<BuffManager> ().updateBuff (buff);
			buffCell = null;
		} 
		else 
		{
			GameObject cell = Instantiate (cellPrefab, list.transform);
			cell.GetComponent<BuffManager> ().setBuff (buff);
		}
	}

	public void removeBuffs(List<Buff> buffs)
	{
		if (buffs == null)
			return;
		int size = buffs.Count;
		for (int i = 0; i < size; i++) 
			removeBuff (buffs [i].buffid);
		//buffs.Clear ();
		buffs = null;
	}

	public void removeBuff(int buffid)
	{
		int size = list.transform.childCount;
		List<string> buffs = new List<string> ();
		List<string> debuffs = new List<string> ();

		for (int i = 0; i < size; i++) 
		{
			int t = list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().buff.buffid;
			if (t < -1)
				debuffs.Add (list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().buff.name);
			else if (t > 1)
				buffs.Add (list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().buff.name);
		}

		if (buffid == 0) {
			int bsize = buffs.Count;
			int dsize = debuffs.Count;
			int id = Random.Range (0, bsize + dsize);
			if (id < bsize)
				list.transform.Find (buffs [id]).gameObject.GetComponent<BuffManager> ().destroySelf ();
			else
				list.transform.Find (debuffs [id - bsize]).gameObject.GetComponent<BuffManager> ().destroySelf ();
		} else if (buffid == -1) {
			int dsize = debuffs.Count;
			int id = Random.Range (0, dsize);
			list.transform.Find (debuffs [id]).gameObject.GetComponent<BuffManager> ().destroySelf ();
		} else if (buffid == 1) {
			int bsize = buffs.Count;
			int id = Random.Range (0, bsize);
			list.transform.Find (buffs [id]).gameObject.GetComponent<BuffManager> ().destroySelf ();
		} else {
			for (int i = 0; i < size; i++) 
			{
				if (list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().buff.buffid == buffid) {
					list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().destroySelf ();
					return;
				}
			}
		}
	}

	public void takeTurn()
	{
		int size = list.transform.childCount;
		for (int i = size - 1; i >= 0; i--) 
		{
			list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().buffTakeTurn ();
		}
	}

	public void takeBuffEffect()
	{
		int size = list.transform.childCount;
		for (int i = 0; i < size; i++) 
		{
			list.transform.GetChild (i).gameObject.GetComponent<BuffManager> ().buff.takeEffect (creature);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
