using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour {
    private LevelManager levelManager;
    // Start is called before the first frame update
    public AudioClip audioClip;
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
        audioClip = Resources.Load<AudioClip>(ResourcesPath.CLICK_PATH);
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnMouseDown () {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 100);
        if (!EventSystem.current.IsPointerOverGameObject ()) {
            Debug.Log ("restart current level");
            levelManager.Restart ();
        }

    }
}