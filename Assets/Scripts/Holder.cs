using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour {

	// Start is called before the first frame update
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 temp = new Vector2 (transform.position.x, transform.position.y);
			Vector3 pos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			//Debug.Log(temp);
			//Debug.Log(pos);
			if (Vector2.Distance (pos, temp) < 1f) {
				Destroy (gameObject);
			}
		}

	}

	void OnMouseDown () {

	}

}