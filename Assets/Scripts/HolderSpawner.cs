using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderSpawner : MonoBehaviour {

	public GameObject holder_Prefab;

	// Start is called before the first frame update
	void Start () {
		SpawnHolder ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void SpawnHolder () {
		float x, y;
		for (x = -11; x <= 11; x += 0.1f) {
			for (y = -4; y <= 4; y += 0.1f) {
				GameObject holder_Obj = Instantiate (holder_Prefab);

				Vector3 temp;
				temp.x = x;
				temp.y = y;
				temp.z = 0f;
				holder_Obj.transform.position = temp;
			}
		}
	}
}