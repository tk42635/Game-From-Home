using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Restart : MonoBehaviour {
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnMouseDown () {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log ("restart current level");
            levelManager.Restart ();
        }
        
    }
}