using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level14BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numBall;
    public float distance = 1f;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
        SpawnBall ();
        SetCMVcam ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void SpawnBall () {
        GameObject ball_Obj;
        Vector3 base_pos = transform.position;
        base_pos.x = base_pos.x - (float) (numBall - 1) / 2 * distance;
        for (int i = 0; i < numBall; i++) {
            Vector3 temp = base_pos;
            temp.x = temp.x + i * distance;
            ball_Obj = Instantiate (ballPrefab);
            ball_Obj.transform.position = temp;
        }
        levelManager.levelBallExist = numBall;
        levelManager.levelBallArrived = 0;
        levelManager.levelBallMax = numBall;
    }

    public void SetCMVcam () {
        var vcam1 = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCameraBase>();
        vcam1.Follow = GameObject.Find("Ball(Clone)").transform;
    }
}
