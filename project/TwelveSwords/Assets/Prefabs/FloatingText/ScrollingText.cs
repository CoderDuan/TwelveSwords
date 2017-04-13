using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour {

	public GameObject obj;
	public Text text;
	public Controller.State state;
	public Controller controller;

	public float velocity = 120.0f;
	private float alpha = 1.0f;
	public float delay = 0.0f;
	private float duration = 1.5f;
	private float beforeFade = 1.0f;
	private float fade = 0.5f;
	private bool visible = false;

	public void setDuration(float d)
	{
		duration = d;
		beforeFade = d * 0.66f;
		fade = duration - beforeFade;
	}

	// Use this for initialization
	void Start () {
		text.enabled = visible;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		if (delay > 0)
			delay -= dt;
		else {
			if (!visible) {
				visible = true;
				text.enabled = visible;
			}
			Vector3 pos = obj.transform.position;
			pos.y += velocity * dt;
			obj.transform.position = pos;

			if (beforeFade > 0) {
				beforeFade -= dt;
			} else {
				if (alpha > 0) {
					alpha -= dt / fade;
					Color c = text.color;
					c.a = alpha;
					text.color = c;
				} else {
					if (controller)
						controller.setState (state);
					controller = null;
					Destroy (obj);
					obj = null;
					text = null;
				}
			}
		}
	}
}
