using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public int score = 0;
    public int maxlevel = 11;
    public int levelBallExist;
    public int levelBallArrived;
    public int levelBallMax;
    public static readonly int[] requiredScoreToUnlock = { 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 6 };
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


        if (levelBallArrived == levelBallMax && score >= requiredScoreToUnlock[thislevel]) {
            UnlockNextLevel ();
            Instantiate (successDialogue, new Vector3 (0, 0, 0), Quaternion.identity);
        } else {
            Instantiate (failureDialogue, new Vector3 (0, 0, 0), Quaternion.identity);
        }
            

        string thislevelString = "Level: " + thislevel.ToString();

        Dictionary<string, object> levelBallArrivalRate = new Dictionary<string, object> () { 
                {thislevelString, ((double) levelBallArrived / levelBallMax) }
        };
        AnalyticsResult lvlCompBallAR = AnalyticsEvent.LevelComplete ("LevelBallArrivalRate", levelBallArrivalRate);

        Dictionary<string, object> levelScoringRate = new Dictionary<string, object> () { 
                {thislevelString, ((double) score / requiredScoreToUnlock[thislevel]) }
        };
        AnalyticsResult lvlCompScoreAR = AnalyticsEvent.LevelComplete ("LevelScoringRate", levelScoringRate );

        AnalyticsEvent.LevelComplete(SceneManager.GetActiveScene ().name);
    }

    public void UnlockNextLevel () {

    }
    public void Restart () {
        AnalyticsEvent.LevelFail (SceneManager.GetActiveScene ().name);
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
}