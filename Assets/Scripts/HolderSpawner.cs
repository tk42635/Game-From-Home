using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderSpawner : MonoBehaviour {

	public GameObject holder_Prefab;

	//mouse control
	bool prev_mousedown = false;
	int prev_i, prev_j;

	//const
	const float x_base = -2.95f,
		y_base = -3.95f;
	const float step = 0.1f;
	const int i_count = 60,
		j_count = 80;
	const int erase_r = 5;

	bool[, ] holder_exist = new bool[i_count, j_count];

	// Start is called before the first frame update
	void Start () {
		SpawnAllHolder ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			float mouse_x, mouse_y;
			int mouse_i, mouse_j;
			mouse_x = Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
			mouse_y = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
			mouse_i = Mathf.RoundToInt ((mouse_x - x_base) / step);
			mouse_j = Mathf.RoundToInt ((mouse_y - y_base) / step);

			if (prev_mousedown) {

			}
			EraseCircle (mouse_i, mouse_j, erase_r);

			prev_mousedown = true;
			prev_i = mouse_i;
			prev_j = mouse_j;
		}
	}

	//erase the holders within a circle at (o_i, o_j) with radius r
	void EraseCircle (int o_i, int o_j, int r) {
		int i, j;

		for (int i_offset = -r; i_offset <= r; i_offset++) {
			for (int j_offset = -r; j_offset <= r; j_offset++) {
				if (i_offset * i_offset + j_offset * j_offset < r * r) {
					i = o_i + i_offset;
					j = o_j + j_offset;
					if (i >= 0 && i < i_count && j >= 0 && j < j_count) {
						if (holder_exist[i, j]) {
							EraseHolder (i, j);
						}
					}
				}
			}
		}
	}

	//erase the holder at (i, j)
	void EraseHolder (int i, int j) {
		GameObject holder_Obj;

		holder_Obj = GameObject.Find ("smallholder_" + i + "_" + j);
		Destroy (holder_Obj);
		holder_exist[i, j] = false;
	}

	//spawn all holders in the map
	public void SpawnAllHolder () {
		for (int i = 0; i < i_count; i++) {
			for (int j = 0; j < j_count; j++) {
				SpawnHolder (i, j);
			}
		}
	}

	//spawn a holder at (i, j)
	public void SpawnHolder (int i, int j) {
		GameObject holder_Obj;
		float x, y;

		x = x_base + i * step;
		y = y_base + j * step;

		holder_Obj = Instantiate (holder_Prefab, new Vector3 (x, y, 0f), Quaternion.identity);
		holder_Obj.name = "smallholder_" + i + "_" + j;
		holder_exist[i, j] = true;
	}
}