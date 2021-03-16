using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelSelector : MonoBehaviour {
    public Button[] levelButtons;

    void Start () {
        levelButtons = FindObjectsOfType<Button>();
        int levelReached = PlayerPrefs.GetInt ("levelReached", 1);
        Debug.Log ("levelReached: " + levelReached);
        for (int i = 0; i < levelButtons.Length; i++) {
            if(levelButtons[i].tag.Equals("playbutton"))
                {int idx = Int32.Parse(levelButtons[i].name);
                if (idx > levelReached) {
                    Debug.Log ("lock: " + idx);
                    levelButtons[i].interactable = false;
                }}
        }
    }

    public void Select (string levelName) {
        Debug.Log ("Enter: " + levelName);
        SceneManager.LoadScene (levelName);
    }
}