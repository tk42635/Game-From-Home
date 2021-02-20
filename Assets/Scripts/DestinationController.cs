using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour
{
    public int numBall;
    // Start is called before the first frame update
    void Start()
    {
        numBall = FindObjectOfType<BallSpawner> ().numBall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
