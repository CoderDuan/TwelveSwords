using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffListManager : MonoBehaviour {

	public GameObject list;
	public GameObject cellPrefab;
	public Creature creature;

	public void addBuff(Buff buff)
	{
		GameObject cell = Instantiate(cellPrefab, list.transform);
		cell.GetComponent<BuffManager> ().setBuff (buff);
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
		for (int i = size - 1; i >= 0; i++) 
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
