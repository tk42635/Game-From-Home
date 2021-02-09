using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public GameObject ball_Prefab;

    // Start is called before the first frame update
    void Start () {
        SpawnBall ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void SpawnBall () {
        GameObject ball_Obj = Instantiate (ball_Prefab);

        Vector3 temp = transform.position;
        ball_Obj.transform.position = temp;

        ball_Obj = Instantiate (ball_Prefab);

        temp = transform.position;
        temp.x = temp.x + 1f;
        ball_Obj.transform.position = temp;
    }
}