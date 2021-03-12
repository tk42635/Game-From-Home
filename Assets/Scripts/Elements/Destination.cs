using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Destination : MonoBehaviour {
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
        levelManager.levelBallExist -= 1;
        levelManager.levelBallArrived += 1;
        if (levelManager.levelBallExist == 0)
            levelManager.LevelDone ();

        AnalyticsResult analyticsResult = Analytics.CustomEvent (
            "LevelWin",
            new Dictionary<string, object> { { "Level", 1 },
                { "NumBallToWin", (levelManager.levelBallMax - levelManager.levelBallArrived) }
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
    }
}