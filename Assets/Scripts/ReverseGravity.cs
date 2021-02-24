using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        Destroy (gameObject);

        Rigidbody2D RIG = other.GetComponent<Rigidbody2D> ();
        RIG.gravityScale = -0.07f;

    }
}