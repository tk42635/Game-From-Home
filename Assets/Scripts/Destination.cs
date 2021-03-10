using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Destination : MonoBehaviour {
    private DestinationController dc;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        dc = FindObjectOfType<DestinationController> ();
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {

        Destroy (other.gameObject);
        dc.numBall -= 1;
        AnalyticsResult analyticsResult = Analytics.CustomEvent (
            "LevelWin",
            new Dictionary<string, object> { { "Level", 1 },
                { "NumBallToWin", (2 - dc.numBall) }
            }
        );
        Debug.Log ("analyticsResult: " + analyticsResult);

        int levelScore = levelManager.score;
        Analytics.CustomEvent (
            "DiamondCollect",
            new Dictionary<string, object> { { "Level", 1 },
                { "NumDiamondCollect", levelScore }
            }
        );

        if (dc.numBall == 0) Application.Quit ();
    }
}