using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderSpawner : MonoBehaviour {

	public GameObject holder_Prefab;

	//mouse control
	bool prev_mousedown = false;
	int prev_i, prev_j;

	//const
	public const float x_base = -2.4f;
	public const float y_base = -5f;
	public const float step = 0.05f;

	const int initial_i_count = 3;
	const int initial_j_count = 6;
	const int initial_e = 32;
	const int i_count = initial_i_count * initial_e;
	const int j_count = initial_j_count * initial_e;

	const int erase_r = 4;

	int[, ] holder_info = new int[i_count, j_count];

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
			Debug.Log ((prev_mousedown, prev_i, prev_j, mouse_i, mouse_j));
			//Rapid mouse drag detected
			if (prev_mousedown && (Mathf.Abs (prev_i - mouse_i) > 1 || Mathf.Abs (prev_j - mouse_j) > 1)) {
				EraseLine (prev_i, prev_j, mouse_i, mouse_j);
			}
			EraseCircle (mouse_i, mouse_j, erase_r);

			prev_mousedown = true;
			prev_i = mouse_i;
			prev_j = mouse_j;
		} else {
			prev_mousedown = false;
		}
	}

	//simulate the erase of a line segment drag
	public void EraseLine (int i_begin, int j_begin, int i_end, int j_end) {
		Debug.Log ((i_begin, j_begin, i_end, j_end));
		if (Mathf.Abs (i_begin - i_end) <= 1 && Mathf.Abs (j_begin - j_end) <= 1) {
			EraseCircle (i_begin, j_begin, erase_r);
			EraseCircle (i_end, j_end, erase_r);
		} else {
			EraseLine (i_begin, j_begin, (i_begin + i_end) / 2, (j_begin + j_end) / 2);
			EraseLine ((i_begin + i_end) / 2, (j_begin + j_end) / 2, i_end, j_end);
		}
	}

	//erase the holders within a circle at (o_i, o_j) with radius r
	public void EraseCircle (int o_i, int o_j, int r) {
		int i, j;

		for (int i_offset = -r; i_offset <= r; i_offset++) {
			for (int j_offset = -r; j_offset <= r; j_offset++) {
				if (i_offset * i_offset + j_offset * j_offset < r * r) {
					i = o_i + i_offset;
					j = o_j + j_offset;
					if (i >= 0 && i < i_count && j >= 0 && j < j_count) {
						if (holder_info[i, j] > 0) {
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

		holder_Obj = GameObject.Find ("holder_" + holder_info[i, j] + "_" + i + "_" + j);
		Destroy (holder_Obj);
		holder_info[i, j] = 0;
	}

	//spawn all holders in the map
	public void SpawnAllHolder () {
		for (int i = 0; i < i_count; i += initial_e) {
			for (int j = 0; j < j_count; j += initial_e) {
				SpawnHolder (initial_e, i, j);
			}
		}
	}

	//spawn a holder at (i, j) with edge e, mark all the info inside the holder as e
	public void SpawnHolder (int e, int i, int j) {
		GameObject holder_Obj;
		float x, y;

		x = x_base + i * step + e * step / 2;
		y = y_base + j * step + e * step / 2;

		holder_Obj = Instantiate (holder_Prefab, new Vector3 (x, y, 0f), Quaternion.identity);
		holder_Obj.transform.localScale = new Vector3 (e * step, e * step, 1f);
		holder_Obj.name = "holder_" + e + "_" + i + "_" + j;

		for (int i_offset = i; i_offset < i + e; i_offset++) {
			for (int j_offset = j; j_offset < j + e; j_offset++) {
				holder_info[i_offset, j_offset] = e;
			}
		}
	}
}