using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatforms : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    void OnTriggerEnter2D (Collider2D other) {

        // need to change the tag of the element
        if (other.tag == "Player") {
            Destroy (gameObject);
        }
    }
}