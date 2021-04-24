using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class HolderSpawner : MonoBehaviour {

	public GameObject holder_Prefab;

	//mouse control
	bool prev_mousedown = false;
	int prev_i, prev_j;

	//const

	//base: bottom left
	//step: side length of the smallest holder
	public const float x_base = -2.4f;
	public const float y_base = -5.2f;
	public const float step = 0.05f;

	//initial-holder:
	//horizontal: initial_i_count
	//vertical: initial_i_count
	//vertical: initial_i_count
	const int initial_i_count = 3;
	const int initial_j_count = 6;
	const int initial_s = 32;
	const int i_count = initial_i_count * initial_s;
	const int j_count = initial_j_count * initial_s;

	//holder_info: store the side length of the square to which each pixel belongs
	//holder_info_temp: used for comparison to reduce repeated changes
	int[] holder_info = new int[i_count * j_count];
	int[] holder_info_temp = new int[i_count * j_count];

	//erase_list: store holder's information for delayed destruction
	List<int[]> erase_list = new List<int[]> ();

	// Start is called before the first frame update
	void Start () {
		SpawnAllHolder ();
	}

	// Update is called once per frame
	void Update () {
		if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton (0)) {
			float mouse_x, mouse_y;
			int mouse_i, mouse_j;

			//translate the mouse position
			mouse_x = Camera.main.ScreenToWorldPoint (Input.mousePosition).x;
			mouse_y = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
			mouse_i = Mathf.RoundToInt ((mouse_x - x_base) / step);
			mouse_j = Mathf.RoundToInt ((mouse_y - y_base) / step);

			//Rapid mouse drag detected
			if (prev_mousedown && (Mathf.Abs (prev_i - mouse_i) > 1 || Mathf.Abs (prev_j - mouse_j) > 1)) {
				EraseLine (prev_i, prev_j, mouse_i, mouse_j);
			}

			EraseCircle_4 (mouse_i, mouse_j);

			prev_mousedown = true;
			prev_i = mouse_i;
			prev_j = mouse_j;
		} else {
			prev_mousedown = false;
		}
	}

	//simulate the erase of a line segment drag
	public void EraseLine (int i_begin, int j_begin, int i_end, int j_end) {
		if (Mathf.Abs (i_begin - i_end) <= 1 && Mathf.Abs (j_begin - j_end) <= 1) {
			EraseCircle_4 (i_begin, j_begin);
			EraseCircle_4 (i_end, j_end);
		}
		//recursion
		else {
			EraseLine (i_begin, j_begin, (i_begin + i_end) / 2, (j_begin + j_end) / 2);
			EraseLine ((i_begin + i_end) / 2, (j_begin + j_end) / 2, i_end, j_end);
		}
	}

	//erase the holders within a circle at (o_i, o_j) with radius r
	public void EraseCircle (int o_i, int o_j, int r) {
		int i, j;

		for (int i_offset = -r; i_offset <= r; i_offset++) {
			i = o_i + i_offset;
			if (i < 0 || i >= i_count)
				continue;
			for (int j_offset = -r; j_offset <= r; j_offset++) {
				j = o_j + j_offset;
				if (j < 0 || j >= j_count)
					continue;
				if (i_offset * i_offset + j_offset * j_offset < r * r) {
					//for holders inside the circle
					if (holder_info[i + j * i_count] > 0) {
						EraseHolder (i, j);
					}
				}
			}
		}
		EraseSubmit ();
	}

	//erase the holders within a circle at (o_i, o_j) with radius 4
	public void EraseCircle_4 (int o_i, int o_j) {
		int i, j, r = 3;

		for (int i_offset = -r; i_offset <= r; i_offset++) {
			i = o_i + i_offset;
			if (i < 0 || i >= i_count)
				continue;
			for (int j_offset = -r; j_offset <= r; j_offset++) {
				j = o_j + j_offset;
				if (j < 0 || j >= j_count)
					continue;
				//cut corners to avoid complicated calculations
				if (Mathf.Abs (i_offset * j_offset) < 9) {
					if (holder_info[i + j * i_count] > 0) {
						EraseHolder (i, j);
					}
				}
			}
		}
		EraseSubmit ();
	}

	//erase the holder at (i, j)
	void EraseHolder (int i, int j) {
		int i_start, j_start;
		int ptr = i + j * i_count;
		//side: the side length of the holder to which the current position belongs
		int side = holder_info[ptr];

		//the holder to be deleted actually exists, add it to the list
		if (side == holder_info_temp[ptr])
			erase_list.Add (new int[] { side, i - i % side, j - j % side });

		//split the holder of the current position into four parts until the side length is 1
		while (side > 1) {
			i_start = i - i % side;
			j_start = j - j % side;

			for (int i_offset = i_start; i_offset < i_start + side; i_offset++) {
				for (int j_offset = j_start; j_offset < j_start + side; j_offset++) {
					holder_info[i_offset + j_offset * i_count] = side / 2;
				}
			}
			side = side / 2;
		}
		//erase the holder at this position
		holder_info[ptr] = 0;
	}

	//perform the erasure
	void EraseSubmit () {
		GameObject holder_Obj;
		//spawn new holders according to holder_info
		for (int i = 0; i < i_count; i++) {
			for (int j = 0; j < j_count; j++) {
				int ptr = i + j * i_count;
				if (holder_info[ptr] != holder_info_temp[ptr] && holder_info[ptr] != 0) {
					//at the corner of the holder
					if (i % holder_info[ptr] == 0 && j % holder_info[ptr] == 0) {
						SpawnHolder (holder_info[ptr], i, j);
					}
				}
			}
		}
		//remove the big holders in the list
		foreach (int[] erase_holder in erase_list) {
			holder_Obj = GameObject.Find ("holder_" + erase_holder[0] + "_" + erase_holder[1] + "_" + erase_holder[2]);
			Destroy (holder_Obj);
		}
		//empty the list and update the data
		erase_list.Clear ();
		holder_info.CopyTo (holder_info_temp, 0);
	}

	//spawn all holders in the map
	public void SpawnAllHolder () {
		for (int i = 0; i < i_count; i += initial_s) {
			for (int j = 0; j < j_count; j += initial_s) {
				SpawnHolder (initial_s, i, j);
			}
		}
		for (int i = 0; i < i_count; i++) {
			for (int j = 0; j < j_count; j++) {
				holder_info[i + j * i_count] = initial_s;
			}
		}
		holder_info.CopyTo (holder_info_temp, 0);
	}

	//spawn a holder at (i, j) with side s, mark all the info inside the holder as s
	public void SpawnHolder (int s, int i, int j) {
		GameObject holder_Obj;
		float x, y;

		//calculate the actual position of the holder center
		x = x_base + i * step + s * step / 2;
		y = y_base + j * step + s * step / 2;

		//determine position, scale, and rename the corresponding holder
		holder_Obj = Instantiate (holder_Prefab, new Vector3 (x, y, 0f), Quaternion.identity);
		holder_Obj.transform.localScale = new Vector3 (s * step, s * step, 1f);
		holder_Obj.name = "holder_" + s + "_" + i + "_" + j;
	}
}