using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public int score = 0;
    public int maxlevel = 2;
    public int levelBallExist;
    public int levelBallArrived;
    public int levelBallMax;

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
        if (levelBallArrived == levelBallMax)
            NextLevel ();
        else
            Restart ();
    }
    public void Restart () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
    public void NextLevel () {
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        int nextlevel = thislevel + 1;
        if (nextlevel <= maxlevel)
            SceneManager.LoadScene (nextlevel.ToString ());
        else
            SceneManager.LoadScene ("Menu");
    }
    public void BacktoMenu () {
        SceneManager.LoadScene ("Level Selector");
    }
}