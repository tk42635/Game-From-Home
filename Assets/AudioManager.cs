using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        Debug.Log("set bgm volumn: " + volume);
        audioMixer.SetFloat("MasterVolume", getVolume(volume));
        
    }

    public void SetBGMVolume(float volume)    
    {
        //Debug.Log("set bgm volumn: " + volume);
        audioMixer.SetFloat("BGMVolume", getVolume(volume));
        
    }

    public void SetSoundEffectVolume(float volume)  
    {
        audioMixer.SetFloat("SoundEffectVolume", getVolume(volume));
    }

    //scale from float to db
    private float getVolume(float value)
    {
        return 20 * value - 5;
    }
}
