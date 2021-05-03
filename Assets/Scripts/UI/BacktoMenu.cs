using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BacktoMenu : MonoBehaviour {
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnMouseDown () {
        if (!EventSystem.current.IsPointerOverGameObject ()) {
            Debug.Log ("Back to menu");
            levelManager.BacktoMenu ();
        }

    }
}