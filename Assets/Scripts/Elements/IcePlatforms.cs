using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatforms : MonoBehaviour {
    private bool firstTime;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start () {
        firstTime = true;
    }

    // Update is called once per frame
    void Update () {
        m_SpriteRenderer = GetComponent<SpriteRenderer> ();
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

    void OnCollisionExit2D (Collision2D collision) {
        if (firstTime == true) {
            firstTime = false;
            m_SpriteRenderer.color = Color.gray;
        } else
            Destroy (gameObject);
    }
}