using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour {
    public int diamondValue = 1;
    private LevelManager levelManager;
    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start () {
        levelManager = FindObjectOfType<LevelManager> ();
        audioClip = Resources.Load<AudioClip> (ResourcesPath.DIAMONDS_AUDIO_PATH);
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        Destroy (gameObject);
        levelManager.AddScore (diamondValue);
        //AudioSource.PlayClipAtPoint(audioClip, transform.position, 100);
        //audioSource.outputAudioMixerGroup = 

        // audioSource.PlayOneShot(audioClip);

        audioSource.PlayOneShot (audioClip);

    }
}