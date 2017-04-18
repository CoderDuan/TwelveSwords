using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPrepare : MonoBehaviour {

	public float rotate = 12.0f;
	public Vector2 position = new Vector2(-467.5f, 70);
	public GameObject obj;
	//private Vector3 scale;

	// Use this for initialization
	void Start () {
		//scale = obj.transform.localScale;
		obj.GetComponent<RectTransform> ().anchoredPosition = position;
	}
	
	// Update is called once per frame
	void Update () {
		obj.GetComponent<RectTransform> ().Rotate (0.0f, 0.0f, rotate);
		//obj.transform.localScale = scale * Random.Range(0.85f, 1.5f);
	}
}
