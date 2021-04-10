using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public Transform destination;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D other) {
        Transform ball = other.transform;
        ball.parent = transform;
        Vector3 lp = ball.localPosition;
        Quaternion lr = ball.localRotation;
        ball.parent = destination;
        ball.localPosition = lp;
        ball.localRotation = lr;
    }
}