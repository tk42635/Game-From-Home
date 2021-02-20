using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private DestinationController dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = FindObjectOfType<DestinationController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {

        Destroy (other.gameObject);
        dc.numBall -= 1;
        if(dc.numBall == 0)  Application.Quit();
    }
}
