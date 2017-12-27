using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour {

	/*
	 * 備忘録:
	 * - フロントエンドでやるようなTweenアニメーションは、iTweenというのがある(Asset Store経由でダウンロード)
	 */


	/*
	 * 参考URL:
     * 【Unity】iTweenの使い方 / お試し【入門】
	 * http://doggy.hatenablog.com/entry/2016/02/11/121327
	 *
     * [Unity] GameObjectのフェードイン・フェードアウト
     * http://mizutanikirin.net/unity-gameobject%E3%81%AE%E3%83%95%E3%82%A7%E3%83%BC%E3%83%89%E3%82%A4%E3%83%B3%E3%83%BB%E3%83%95%E3%82%A7%E3%83%BC%E3%83%89%E3%82%A2%E3%82%A6%E3%83%88
	 *
     * [Unity]他のオブジェクトについているスクリプトの変数を参照したり関数を実行したりする。
     * https://qiita.com/tsukasa_wear_parker/items/09d4bcc5af3556b9bb3a
	 */

	GameObject main;
	MainScript script;

	private float x;
	private bool hasFaded = false;

	// Use this for initialization
	void Start () {
		main = GameObject.Find ("Manager");
		script = main.GetComponent<MainScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		x += Time.deltaTime * Random.Range(0, 100.0f);
		transform.rotation = Quaternion.Euler(x, 0, 0);

		if ((transform.position.y <= - script.limitPosY || transform.position.y >= script.limitPosY) && !hasFaded) {
			hasFaded = true;

			Hashtable hash = new Hashtable ();
			hash.Add ("alpha", 0);
			hash.Add ("time", 0.3f);
			hash.Add ("delay", 0.2f);
			hash.Add ("oncomplete", "Delete");

			iTween.FadeTo (this.gameObject, hash);
		} else {
			transform.position = new Vector3 (transform.position.x, transform.position.y - script.fallSpeed, transform.position.z);
		}
	}

	void Delete(){
		Destroy (this.gameObject);
	}
}
