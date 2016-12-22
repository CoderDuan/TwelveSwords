using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKillScroll : MonoBehaviour {

    public Skill selectedSkill;

    public GameObject GUI;

    FireBall fireball = new FireBall();

	// Use this for initialization
	void Start () {
		selectedSkill = null;
        init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void init()
    {
        GUI.transform.FindChild("FireballBtn").GetComponent<Button>().interactable = !fireball.isLocked;
    }

    public void setFireball()
    {
        selectedSkill = fireball;
        Debug.Log("貌似正在思考火球术...");
    }
}
