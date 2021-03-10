using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour {
    private BallSpawner bs;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        bs = FindObjectOfType<BallSpawner> ();
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {

        Destroy (other.gameObject);
        bs.numBall -= 1;
        AnalyticsResult analyticsResult = Analytics.CustomEvent (
            "LevelWin",
            new Dictionary<string, object> { { "Level", 1 },
                { "NumBallToWin", (2 - bs.numBall) }
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

        if (bs.numBall == 0) {
            levelManager = FindObjectOfType<LevelManager> ();
            Debug.Log (levelManager.score);
            Debug.Log ("go to next level");
            SceneManager.LoadScene ("Stage2");
        }
    }
}