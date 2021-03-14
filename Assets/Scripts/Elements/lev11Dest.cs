using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class lev11Dest : MonoBehaviour {
    private LevelManager levelManager;
    Color32 thisColor;
    Color32 otherColor;
    public int levelScore;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();   
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        thisColor = gameObject.GetComponent<SpriteRenderer>().color;
        otherColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        if(thisColor.Equals(otherColor)){

            Destroy (other.gameObject);
            
            levelManager.levelBallExist -= 1;
            levelManager.levelBallArrived += 1;
            if (levelManager.levelBallExist == 0){
                levelManager.LevelDone ();

                levelScore = levelManager.score;
                AnalyticsResult analyticsResult = Analytics.CustomEvent (
                    "LevelWin",
                    new Dictionary<string, object> { { "Level", 1 },
                        { "NumBallToWin", (levelManager.levelBallMax - levelManager.levelBallArrived) }
                    }
                );

                Debug.Log ("analyticsResult: " + analyticsResult);
                Analytics.CustomEvent (
                    "DiamondCollect",
                    new Dictionary<string, object> { { "Level", 1 },
                        { "NumDiamondCollect", levelScore }
                    }
                );
            } 
        }
    }
}
