using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// 変数の定義と初期化
	public float flap = 550f;
	public float scroll = 10f;
	Rigidbody2D rb2d;

	// Updateの前に1回だけ呼ばれるメソッド
	void Start() {
		// Rigidbody2Dをキャッシュする
		rb2d = GetComponent<Rigidbody2D>();
	}

	// シーン中にフレーム毎に呼ばれるメソッド
	void Update() {
		// xの正方向にscrollスピードで移動
		rb2d.velocity = new Vector2(scroll, rb2d.velocity.y);

		// スペースキーが押されたら
		if (Input.GetKeyDown(KeyCode.Space)) {
			// 落下速度をリセット
			rb2d.velocity = Vector2.zero;
			// (0,1)方向に瞬間的に力を加えて跳ねさせる
			rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
		}
	}

	// ColliderのIs Triggerにチェック有のオブジェクトとの衝突を検出する関数
	void OnTriggerEnter2D(Collider2D col){
		// CountZoneのタグが付いたオブジェクトと衝突したとき
		if(col.gameObject.tag == "CountZone"){
			// ScoreスクリプトのAddScore関数に値を送信する
			GameObject.Find("ScoreGUI").SendMessage("AddScore", 1);
			GameObject.Find("ScoreGUI");
		}
	}
}