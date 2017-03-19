using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

    public Text text;
    public GameObject window;
    public Animation anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeContent(string str)
    {
        text.text = str;
    }
    
    public void show()
    {
        window.SetActive(true);
        anim.Play("showAndFade");
    }
    public void hide()
    {
        window.SetActive(false);
    }
}
