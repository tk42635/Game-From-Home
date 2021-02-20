using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private BallSpawner bs;
    // Start is called before the first frame update
    void Start()
    {
        bs = FindObjectOfType<BallSpawner> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {

        Destroy (other.gameObject);
        Destroy (gameObject);
        bs.numBall -= 1;
        if(bs.numBall == 0)  SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
