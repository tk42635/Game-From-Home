using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostToLeft : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        Destroy (gameObject);
        int x = Mathf.RoundToInt ((transform.position.x - HolderSpawner.x_base) / HolderSpawner.step);
        int y = Mathf.RoundToInt ((transform.position.y - HolderSpawner.y_base) / HolderSpawner.step);

        // int end_x = Mathf.RoundToInt(other.transform.position.x - 4 * Mathf.Cos(2f * Mathf.PI / 180 * r));
        // int end_y = Mathf.RoundToInt(other.transform.position.y - 4 * Mathf.Sin(2f * Mathf.PI / 180 * r));
        int end_x = x - 60;
        int end_y = y;

        GameObject.Find ("HolderSpawner").GetComponent<HolderSpawner> ().EraseLine (x, y, end_x, end_y);

        Rigidbody2D RIG = other.GetComponent<Rigidbody2D> ();
        other.transform.position = transform.position;
        RIG.gravityScale = 0;
        //RIG.AddForce (new Vector3 (0, 9.81f, 0), ForceMode2D.Force);
        RIG.velocity = new Vector3 (2, 0, 0);
        // RIG.AddForce (new Vector3 (5, 0, 0), ForceMode2D.Impulse);

        // Destroy(gameObject);
    }
}