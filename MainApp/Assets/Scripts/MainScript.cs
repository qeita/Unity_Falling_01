using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

	public string prefabName = "Cube";
	public float fallSpeed = 0.1f;
	public float limitPosY = 5.0f;

	/*
	 * 備忘録:
	 * - 座標を取得しただけでは、その位置にPrefabを生成できない(スクリーン座標とワールド座標で値が違うため)
	 * - Prefabからインスタンスを生成するときは、ポジションと角度を指定できるが、スケールは生成後に設定した
	 * - Prefabより生成したインスタンスの色を変えるときは、Rendererコンポーネントのマテリアルから参照する
	 */

	/*
	 * 参考URL:
	 * https://qiita.com/kenta71/items/3629ae1fa47eba9a38d7
	 * 
	 * Unityでクリックした座標の取得
	 * http://code.hildsoft.com/entry/2017/06/21/144211
	 * 
	 * Prefabからインスタンスを生成
	 * https://qiita.com/2dgames_jp/items/8a28fd9cf625681faf87
	 * 
	 * クリックした位置にPrefabを生成
	 * https://gist.github.com/Buravo46/8018394
	 *
	 * ランダムにカラーを生成
     * https://gist.github.com/hiroyukihonda/8430454
	 *
     * [Unity] prefabで生成した複数のオブジェクトの色を分ける方法
     * https://teratail.com/questions/52466
	 *
     * [Unity]Instantiateで生成したオブジェクトを特定のオブジェクトの入れ子にする
     * https://increment-log.com/unity-instantiate-nesting/
	 */

	private GameObject container;

	// Use this for initialization
	void Start () {
		if (prefabName == "") {
			prefabName = "Cube";
		}
		if (fallSpeed == 0) {
			fallSpeed = 0.1f;
		}
		if (limitPosY == 0) {
			limitPosY = 5.0f;
		}
		container = GameObject.Find ("InsContainer");
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButton (0)) {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 10f;

		GameObject prefab = (GameObject)Resources.Load ("Prefabs/" + prefabName);
		GameObject ins = Instantiate (prefab, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);

		// insContainerオブジェクトの入れ子に指定
		ins.transform.parent = container.transform;

		// スケール
		float _scale = Random.Range (0, 1.0f);
		ins.transform.localScale = new Vector3 (_scale, _scale, _scale);

		// カラー
		Color rand = new Color(Random.value, Random.value, Random.value, 1.0f);
		ins.GetComponent<Renderer> ().material.color = rand;

//		}
	}
}
