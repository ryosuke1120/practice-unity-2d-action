using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public GUIText scoreGUI;
	private int score;

	// シーン開始時に一度だけ呼ばれる関数
	void Start(){
		score = 0;
	}

	// スコアの加算
	void AddScore(int s){
		// 現在のスコアをsを足したものに更新
		score = score + s;
	}

	// シーン中にフレーム毎に呼ばれる関数
	void Update () {
		// スコアの表示
		scoreGUI = gameObject.GetComponent<GUIText>();
		scoreGUI.text = "" + score;
	}
}
