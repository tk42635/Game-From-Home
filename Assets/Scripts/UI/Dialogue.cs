using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        gameObject.SetActive (true);
    }

    // Update is called once per frame
    void Update () {

    }

    public void onShow () {
        gameObject.SetActive (true);
    }
    public void onRetry () {
        gameObject.SetActive (false);
    }
    public void onContinue () {
        gameObject.SetActive (false);
    }

}