using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedPlank : MonoBehaviour {

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        int x = Mathf.RoundToInt ((transform.position.x - HolderSpawner.x_base) / HolderSpawner.step);
        int y = Mathf.RoundToInt ((transform.position.y - HolderSpawner.y_base) / HolderSpawner.step);
        int r = Mathf.RoundToInt (transform.rotation.z);
        int end_x = x + 60;
        int end_y = y;

        GameObject.Find ("HolderSpawner").GetComponent<HolderSpawner> ().EraseCircle (x, y, 20);
    }
    void OnCollisionStay2D (Collision2D other) {
        Rigidbody2D RIG = other.gameObject.GetComponent<Rigidbody2D> ();
        // Debug.Log("Collision!");
        if (Mathf.Abs (RIG.velocity.x) < 0.1f) {
            if (other.transform.position.x >= gameObject.transform.position.x)
                RIG.velocity = new Vector3 (0.1f, 0, 0);
            else
                RIG.velocity = new Vector3 (-0.1f, 0, 0);
        }

    }
}