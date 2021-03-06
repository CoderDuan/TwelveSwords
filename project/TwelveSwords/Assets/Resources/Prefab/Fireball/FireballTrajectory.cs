﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballTrajectory : MonoBehaviour {

	public GameObject obj;
	public Image img;
	public Controller controller;

	public Vector2 start = new Vector2(-467.5f, 70);
	public Vector2 destination = new Vector2(467.5f, 45);
	private Vector2 velocity;
	public float rotate = 8.0f;

	public float alpha = 1.0f;
	public float delay = 0.0f;
	public float duration = 1.5f;
	public float expand = 0.5f;
	private float expanding;

	private bool visible = false;
	private bool hit = false;

	void disturb()
	{
		int seed = (int)(long.Parse(System.DateTime.Now.ToString ("yyyyMMddHHmmssfff")) % int.MaxValue);
		Random.InitState (seed);	
		destination.x += Random.Range (-15.0f, 15.0f);
		destination.y += Random.Range (-50.0f, 50.0f);
	}

	// Use this for initialization
	void Start () {
		expanding = obj.transform.localScale.x * 2.0f;
		controller = GameObject.Find ("ControllerObj").GetComponent<Controller> ();
		disturb ();
		velocity = (destination - start) / duration;
		//setBaseProperty (start, destination, duration);		
		Vector2 pos = obj.GetComponent<RectTransform>().anchoredPosition;
		pos.x = start.x;
		pos.y = start.y;	
		obj.GetComponent<RectTransform>().anchoredPosition = pos;

		img.enabled = visible;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		if (delay > 0)
			delay -= dt;
		else 
		{
			if (!visible) {
				visible = true;
				img.enabled = visible;
			}
			obj.GetComponent<RectTransform> ().Rotate (0.0f, 0.0f, rotate);
			if (duration > 0) 
			{
				// move
				duration -= dt;
				Vector2 pos = obj.GetComponent<RectTransform>().anchoredPosition;
				pos.x += velocity.x * dt;
				pos.y += velocity.y * dt;
				obj.GetComponent<RectTransform>().anchoredPosition = pos;
			} else 
			{
				// hit
				if (!hit) 
				{
					if (controller) 
						controller.recieveEffectResponse (obj.GetComponent<Identity>().stage);
					hit = true;
				}
				// expand
				if (alpha > 0) 
				{
					alpha -= dt / expand;
					Color c = img.color;
					c.a = alpha;
					img.color = c;

					Vector3 scale = obj.transform.localScale;
					float ex = expanding * dt / expand;
					scale.x += ex;
					scale.y += ex;
					obj.transform.localScale = scale;
				} 
				else 
				{
					controller = null;
					Destroy (obj);
					obj = null;
					img = null;
				}
			}
		}		
	}
}
