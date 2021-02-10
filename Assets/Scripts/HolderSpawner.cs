using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderSpawner : MonoBehaviour {

	public GameObject holder_Prefab;
	const float x_base = -2.95f,
		y_base = -3.95f;
	const float step = 0.1f;
	const int x_count = 60,
		y_count = 80;
	const int erase_r = 5;

	bool[, ] holder_exist = new bool[x_count, y_count];

	// Start is called before the first frame update
	void Start () {
		SpawnHolder ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector2 pos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			GameObject holder_Obj;
			int mouse_x, mouse_y;
			int x, y;
			mouse_x = Mathf.RoundToInt ((Camera.main.ScreenToWorldPoint (Input.mousePosition).x - x_base) / step);
			mouse_y = Mathf.RoundToInt ((Camera.main.ScreenToWorldPoint (Input.mousePosition).y - y_base) / step);
			for (int i = -erase_r; i <= erase_r; i++) {
				for (int j = -erase_r; j <= erase_r; j++) {
					if (i * i + j * j < erase_r * erase_r) {
						x = Mathf.RoundToInt ((Camera.main.ScreenToWorldPoint (Input.mousePosition).x - x_base) / step) + i;
						y = Mathf.RoundToInt ((Camera.main.ScreenToWorldPoint (Input.mousePosition).y - y_base) / step) + j;
						if (x >= 0 && x < x_count && y >= 0 && y < y_count) {
							if (holder_exist[x, y]) {
								holder_Obj = GameObject.Find ("smallholder_" + x + "_" + y);
								Destroy (holder_Obj);
								holder_exist[x, y] = false;
							}
						}
					}
				}
			}
		}
	}

	public void SpawnHolder () {
		GameObject holder_Obj;
		float x, y;
		for (int i = 0; i < x_count; i++) {
			for (int j = 0; j < y_count; j++) {
				x = x_base + i * step;
				y = y_base + j * step;
				holder_Obj = Instantiate (holder_Prefab, new Vector3 (x, y, 0f), Quaternion.identity);
				holder_Obj.name = "smallholder_" + i + "_" + j;
				holder_exist[i, j] = true;
			}
		}
	}
}