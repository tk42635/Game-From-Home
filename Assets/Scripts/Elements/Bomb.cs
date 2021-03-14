using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        Destroy (other.gameObject);
        Destroy (gameObject);
        // levelManager.levelBallExist -= 1;
        // if (levelManager.levelBallExist == 0)
        levelManager.LevelDone ();
    }
}