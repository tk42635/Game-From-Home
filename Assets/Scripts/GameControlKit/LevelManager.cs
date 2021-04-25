using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public int score = 0;
    public const int maxlevel = 15;
    public int levelBallExist;
    public int levelBallArrived;
    public int levelBallMax;
    public static readonly int[] requiredScoreToUnlock = { 0, 3, 3, 3, 3, 3, 1, 2, 3, 3, 3, 6, 0, 0, 6, 2 };
    public static readonly int[] totalScore = { 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 10, 0, 0, 10, 3 };
    public GameObject successDialogue;
    public GameObject failureDialogue;
    public GameObject ItemDialogue;
    private BagManager bagManager;

    public static bool protectorAvtivated = false, doublerActivated = false, diamondActivated = false;

    public int selectedItemID = -1;

    // Start is called before the first frame update
    void Start () {
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        PlayerPrefs.SetInt ("CurLevel", thislevel);
    }

    // Update is called once per frame
    void Update () {

    }
    public void AddScore (int diamondValue) {
        score += diamondValue;

    }
    public void LevelDone () {
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        Debug.Log ("thislevel:" + thislevel);
        if(doublerActivated) 
        {
            score = score * 2 > requiredScoreToUnlock[thislevel] ? requiredScoreToUnlock[thislevel] : score * 2;
            doublerActivated = false;
        }
        if(diamondActivated)
        {
            score = score + 1 > requiredScoreToUnlock[thislevel] ? requiredScoreToUnlock[thislevel] : score + 1;
            diamondActivated = false;
        }
        
        Debug.Log ("Score:" + score);
        

        float mainCameraY = GameObject.Find ("Main Camera").transform.position.y;
        if (levelBallArrived == levelBallMax && score >= requiredScoreToUnlock[thislevel]) {
            UnlockNextLevel (thislevel + 1);
            Instantiate (successDialogue, new Vector3 (0, mainCameraY, 0), Quaternion.identity);
        } else {
            Instantiate (failureDialogue, new Vector3 (0, mainCameraY, 0), Quaternion.identity);
        }

        string thislevelString = "Level: " + thislevel.ToString ();

        Dictionary<string, object> levelBallArrivalRate = new Dictionary<string, object> () { { thislevelString, ((double) levelBallArrived / levelBallMax) }
        };
        AnalyticsResult lvlCompBallAR = AnalyticsEvent.LevelComplete ("LevelBallArrivalRate", levelBallArrivalRate);

        Dictionary<string, object> levelScoringRate = new Dictionary<string, object> () { { thislevelString, ((double) score / requiredScoreToUnlock[thislevel]) }
        };
        AnalyticsResult lvlCompScoreAR = AnalyticsEvent.LevelComplete ("LevelScoringRate", levelScoringRate);

        AnalyticsEvent.LevelComplete (SceneManager.GetActiveScene ().name);
    }

    public void UnlockNextLevel (int NextLevel) {
        PlayerPrefs.SetInt (LevelSelector.LEVEL_REACHED, NextLevel);
        if(doublerActivated)
        {
            PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins", 0) + 2);
            doublerActivated = false;
        }
        else
            PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins", 0) + 1);
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
        SceneManager.LoadScene ("Store in Level");
        // if (nextlevel <= maxlevel)
        //     SceneManager.LoadScene (nextlevel.ToString ());
        // else
        //     SceneManager.LoadScene ("Menu");
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

    public void ActivateItem() {
        if(selectedItemID == -1) return;
        Debug.Log("activated " + selectedItemID);
        switch (selectedItemID)
        {
            case 0:
                protectorAvtivated = true;
                break;
            case 1:
                break;
            case 2:
                doublerActivated = true;
                break;
            case 3:
                DestroyAllBombs();
                break;
            case 4:
                diamondActivated = true;
                break;
            case 5:
                break;
        }
        PlayerPrefs.SetInt ("Item_" + selectedItemID, 0);
        selectedItemID = -1;
        
        diamondActivated = true;
        var tmp = GameObject.Find("ItemDialogue");
        GameObject.DestroyImmediate (tmp);

        bagManager = FindObjectOfType<BagManager> ();
        bagManager.Close();
        bagManager.CreateBag();
    }

    public void DestroyAllBombs() {
        var bombs = GameObject.Find("BombLitSprites");
        //var tmp = FindObjectOfType<Bomb> ();
        // foreach (Transform child in bombs) {
        //     Destroy(child.gameObject);
        //  }
        Destroy(bombs);
    }

    public void OpenItemDialogue(int ItemID) {
        selectedItemID = ItemID;
        var tmp = Instantiate (ItemDialogue, new Vector3 (0, 0, 0), Quaternion.identity);
        tmp.name = "ItemDialogue";
    }

    public void CloseItemDialogue() {
        selectedItemID = -1;
        var tmp = GameObject.Find("ItemDialogue");
        GameObject.DestroyImmediate (tmp);
    }



}