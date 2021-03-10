using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public GameObject ballPrefab;
    public int numBall;
    public float distance = 1f;
    // Start is called before the first frame update
    void Start () {
        SpawnBall ();
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
    }
}