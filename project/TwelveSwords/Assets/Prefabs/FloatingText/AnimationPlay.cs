using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour {

    public Animation animation;

    public GameObject gameobj;

	public string animationName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void play()
    {
		animation.Play(animationName);
    }

    public void destroyself()
    {
        Destroy(gameobj);
    }
}
