using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnMouseDown () {
        Debug.Log ("go to next level");
        levelManager.NextLevel ();
    }
}