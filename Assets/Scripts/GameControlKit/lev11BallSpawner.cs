using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lev11BallSpawner : MonoBehaviour {
    public GameObject ballPrefab1;
    public GameObject ballPrefab2;
    public int numBall;
    public float distance = 1f;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
        SpawnBall ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void SpawnBall () {
        GameObject ball_Obj1;
        GameObject ball_Obj2;
        Vector3 base_pos1 = transform.position;
        base_pos1.x = base_pos1.x - (float) (numBall - 1) / 2 * distance;
        Vector3 base_pos2 = transform.position;
        base_pos2.x = base_pos2.x + (float) (numBall + 1) / 2 * distance;
        ball_Obj1 = Instantiate (ballPrefab1);
        ball_Obj1.transform.position = base_pos1;
        ball_Obj2 = Instantiate (ballPrefab2);
        ball_Obj2.transform.position = base_pos2;
        levelManager.levelBallExist = 2;
        levelManager.levelBallArrived = 0;
        levelManager.levelBallMax = 2;
    }
}