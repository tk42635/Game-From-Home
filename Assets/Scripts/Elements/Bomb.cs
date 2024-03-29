using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    private LevelManager levelManager;
    public AudioClip boomAudioClip;
    public AudioClip gameOverAudioClip;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
        boomAudioClip = Resources.Load<AudioClip> (ResourcesPath.BOOM_AUDIO_PATH);
        gameOverAudioClip = Resources.Load<AudioClip> (ResourcesPath.GAME_OVER_AUDIO_PATH);
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (!LevelManager.protectorAvtivated) {
            Destroy (other.gameObject);
            Destroy (gameObject);
            AudioSource.PlayClipAtPoint (boomAudioClip, transform.position, 100);
            AudioSource.PlayClipAtPoint (gameOverAudioClip, transform.position, 100);
            // levelManager.levelBallExist -= 1;
            // if (levelManager.levelBallExist == 0)
            levelManager.LevelDone ();
        } else
        {
            Destroy (gameObject);
            AudioSource.PlayClipAtPoint (boomAudioClip, transform.position, 100);
            AudioSource.PlayClipAtPoint (gameOverAudioClip, transform.position, 100);
            LevelManager.protectorAvtivated = false;
        }
    }
}