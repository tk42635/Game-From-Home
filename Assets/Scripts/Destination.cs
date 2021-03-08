using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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
        AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelWin" + (2 - dc.numBall));
        Debug.Log("analyticsResult: " + analyticsResult);

        if(dc.numBall == 0)  Application.Quit();
    }
}
