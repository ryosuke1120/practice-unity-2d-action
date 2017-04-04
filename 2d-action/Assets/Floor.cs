using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	public float scroll = 0.15f;
	Renderer cRenderer;

	void Awake(){
		cRenderer = GetComponent<Renderer>();
	}

	void Update (){
		float x = Mathf.Repeat(Time.time * scroll, 1);
		Vector2 offset = new Vector2 (x, 0);
		cRenderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	public void Stop (){
		Destroy(this);
	}
}
