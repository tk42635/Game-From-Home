using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMainMenu : MonoBehaviour {
    // Start is called before the first frame update
    public AudioClip audioClip;
    void Start () {
        audioClip = Resources.Load<AudioClip>(ResourcesPath.CLICK_PATH);
    }

    // Update is called once per frame
    void Update () {

    }

    public void OnMouseDown () {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 100);
        SceneManager.LoadScene ("Menu");
    }
}