using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public GameObject scoreGUI;
	public GameObject highscoreGUI;
	private int score;
	private int highScore;

	private GameObject[] scoreObjects;

	void Awake(){
		scoreObjects = GameObject.FindGameObjectsWithTag("Score");
		scoreGUI = scoreObjects[0];
		highscoreGUI = scoreObjects[1];
	}

	// シーン開始時に一度だけ呼ばれる関数
	void Start(){
		score = 0;
		// キーを使って値を取得
		// キーがない場合は第二引数の値を取得
		highScore = PlayerPrefs.GetInt("highScoreKey", 0);
	}

	void Update () {
		// Scoreが現在のハイスコアを上回ったらhighScoreを更新
		if(highScore < score) highScore = score;

		scoreGUI.GetComponent<GUIText>().text = "" + score;
		highscoreGUI.GetComponent<GUIText>().text = "" + highScore;
	}

	public void Save(){
		// メソッドが呼ばれたときのキーと値をセットする
		PlayerPrefs.SetInt("highScoreKey", highScore);
		// キーと値を保存
		PlayerPrefs.Save();
	}

	// スコアの加算
	void AddScore(int s){
		// 現在のスコアをsを足したものに更新
		score = score + s;
	}

	public void Reset(){
		// キーを全て消す
		PlayerPrefs.DeleteAll();
	}

}
