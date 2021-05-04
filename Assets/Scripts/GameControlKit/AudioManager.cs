using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public AudioMixer audioMixer;

    void Start()
    {
        Scrollbar bgmScrollBar = GameObject.Find("BgmScrollbar").GetComponent<Scrollbar>();
        bgmScrollBar.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);

        Scrollbar soundEffectScrollBar = GameObject.Find("SoundEffectScrollbar").GetComponent<Scrollbar>();
        soundEffectScrollBar.value = PlayerPrefs.GetFloat("SoundEffectVolume", 0.5f);
    }

    public void SetMasterVolume (float volume) {
        Debug.Log ("set bgm volumn: " + volume);
        audioMixer.SetFloat("MasterVolume", getVolume(volume));

    }

    public void SetBGMVolume (float volume) {
        //Debug.Log("set bgm volumn: " + volume);
        PlayerPrefs.SetFloat("BGMVolume", volume);
        audioMixer.SetFloat ("BGMVolume", getVolume (volume));

    }

    public void SetSoundEffectVolume (float volume) {
        PlayerPrefs.SetFloat("SoundEffectVolume", volume);
        audioMixer.SetFloat ("SoundEffectVolume", getVolume (volume));
    }

    //scale from float to db
    private float getVolume (float value) {
        return 40 * value - 20;
    }
}