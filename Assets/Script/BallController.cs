using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
       // need respawn
        if (other.tag == "FallDetector") {
            transform.position = respawnPoint;
            Debug.Log("Respawn");
        }


        // next level
        if (other.tag == "Finish")
        {
            
            Debug.Log("Finish");
        }
    }
}
