
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public int score = 0;
    public int maxlevel = 15;
    public int levelBallExist;
    public int levelBallArrived;
    public int levelBallMax;
    public static readonly int[] requiredScoreToUnlock = { 0, 3, 3, 3, 3, 3, 1, 2, 3, 3, 3, 6, 0, 0, 6, 2 };
    public static readonly int[] totalScore = { 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 10, 0, 0, 10, 3 };
    public GameObject successDialogue;
    public GameObject failureDialogue;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
    public void AddScore (int diamondValue) {
        score += diamondValue;

    }
    public void LevelDone () {
        Debug.Log ("Score:" + score);
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        Debug.Log ("thislevel:" + thislevel);

        float mainCameraY = GameObject.Find("Main Camera").transform.position.y;
        if (levelBallArrived == levelBallMax && score >= requiredScoreToUnlock[thislevel]) {
            UnlockNextLevel (thislevel + 1);
            Instantiate (successDialogue, new Vector3 (0, mainCameraY, 0), Quaternion.identity);
        } else {
            Instantiate (failureDialogue, new Vector3 (0, mainCameraY, 0), Quaternion.identity);
        }



        



        // AnalyticsEvent.LevelComplete (SceneManager.GetActiveScene ().name);
        



        // Debug.Log(thislevelDiamondScore + score);
        // Debug.Log("level number: " + SceneManager.GetActiveScene().name);

        

        string thislevelDiamondScore = "Level: " + thislevel.ToString() + " diamond score";
        Dictionary<string, object> diamondScoreAnalyticsData = new Dictionary<string, object>
            {
                {thislevelDiamondScore, score},
            };

        AnalyticsResult diamondScoreEvent = Analytics.CustomEvent(("DiamondScoreEvent"), diamondScoreAnalyticsData);
        Debug.Log("diamond event:" + diamondScoreEvent);



        string thislevelScoringRate = "Level: " + thislevel.ToString() + " scoring rate";
        Dictionary<string, object> levelScoringRate = new Dictionary<string, object>() { { thislevelScoringRate, ((double) score / requiredScoreToUnlock[thislevel]) }
        };
        AnalyticsResult diamondScoringRateEvent = Analytics.CustomEvent(("DiamondScoringRateEvent"), levelScoringRate);


        string thislevelString = "Level: " + thislevel.ToString();
        Dictionary<string, object> levelComplete = new Dictionary<string, object>() { { thislevelString,  thislevel.ToString() }
        };
        AnalyticsResult levelCompleteEvent = Analytics.CustomEvent(("LevelCompleteEvent"), levelComplete);



        string thislevelBallAriivalRate = "Level: " + thislevel.ToString() + " ball arrivial rate";
        Dictionary<string, object> levelBallArrivalRate = new Dictionary<string, object>() { { thislevelBallAriivalRate, ((double) levelBallArrived / levelBallMax) }
        };
        AnalyticsResult lvlCompBallAR = AnalyticsEvent.LevelComplete("LevelBallArrivalRateEvent", levelBallArrivalRate);

    }

    public void UnlockNextLevel (int NextLevel) {
        PlayerPrefs.SetInt (LevelSelector.LEVEL_REACHED, NextLevel);
    }

    public void Restart () {
        int thislevel = int.Parse(SceneManager.GetActiveScene().name);
        string thislevelString = "Level: " + thislevel.ToString();
        Dictionary<string, object> levelFail = new Dictionary<string, object>() { { thislevelString,  thislevel.ToString() }
        };
        AnalyticsResult levelCompleteEvent = Analytics.CustomEvent(("LevelFailEvent"), levelFail);

        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    public void NextLevel () {
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        int nextlevel = thislevel + 1;
        Debug.Log ("nextlevel:" + nextlevel);
        Debug.Log ("maxlevel:" + maxlevel);
        if (nextlevel <= maxlevel)
            SceneManager.LoadScene (nextlevel.ToString ());
        else
            SceneManager.LoadScene ("Menu");
    }

    public void BacktoMenu () {
        SceneManager.LoadScene ("Level Selector");
    }

    public int getScore () {
        return score;
    }

    public int getRequiredScore () {
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        return requiredScoreToUnlock[thislevel];
    }

    public int getTotalScore () {
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        return totalScore[thislevel];
    }

}