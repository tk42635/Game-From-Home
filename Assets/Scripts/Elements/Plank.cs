using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour {
    // Start is called before the first frame update
    public AudioClip audioClip;
    void Start () {
        audioClip = Resources.Load<AudioClip>(ResourcesPath.HIT_PLANK_AUDIO_PATH);
    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("onCollisionEnter2D");
        Rigidbody2D RIG = collision.gameObject.GetComponent<Rigidbody2D>();
        if (Mathf.Abs(RIG.velocity.y) > 0.1f)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 100);
        }
    }
    

    void OnCollisionStay2D (Collision2D other) {
        Rigidbody2D RIG = other.gameObject.GetComponent<Rigidbody2D> ();
        // Debug.Log("Collision!");
        if (Mathf.Abs (RIG.velocity.x) < 0.1f) {
            if (other.transform.position.x >= gameObject.transform.position.x)
                RIG.velocity = new Vector3 (0.1f, 0, 0);
            else
                RIG.velocity = new Vector3 (-0.1f, 0, 0);
        }
        

    }
}