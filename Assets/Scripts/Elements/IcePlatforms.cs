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
    void OnCollisionExit2D (Collision2D collision) {
        if (firstTime == true) {
            firstTime = false;
            m_SpriteRenderer.color = Color.gray;
        } else
            Destroy (gameObject);
    }
}