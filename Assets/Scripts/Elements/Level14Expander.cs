using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14Expander : MonoBehaviour {

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        Destroy (gameObject);
        int x = Mathf.RoundToInt ((other.transform.position.x - HolderSpawner.x_base) / HolderSpawner.step);
        int y = Mathf.RoundToInt ((other.transform.position.y - HolderSpawner.y_base) / HolderSpawner.step);
        int r = Mathf.RoundToInt (other.transform.rotation.z);

        // int end_x = Mathf.RoundToInt(other.transform.position.x - 4 * Mathf.Cos(2f * Mathf.PI / 180 * r));
        // int end_y = Mathf.RoundToInt(other.transform.position.y - 4 * Mathf.Sin(2f * Mathf.PI / 180 * r));
        int end_x = x + 60;
        int end_y = y;

        GameObject.Find ("HolderSpawner").GetComponent<Level14HolderSpawner> ().EraseCircle (x, y, 20);

        Rigidbody2D RIG = other.GetComponent<Rigidbody2D> ();
        RIG.velocity = new Vector3 (0, 0, 0);
        //RIG.AddForce (new Vector3 (0, 3, 0), ForceMode2D.Impulse);

        Debug.Log ((x, y));

        // Destroy(gameObject);
    }
}