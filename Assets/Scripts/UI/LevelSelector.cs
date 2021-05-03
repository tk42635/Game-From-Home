using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour, IPointerClickHandler {
    public Button[] levelButtons;
    public const String LEVEL_REACHED = "levelReached";
    int tap = 0;

    void Start () {
        levelButtons = FindObjectsOfType<Button> ();
        int levelReached = PlayerPrefs.GetInt (LevelSelector.LEVEL_REACHED, 1);
        Debug.Log ("levelReached: " + levelReached);
        for (int i = 0; i < levelButtons.Length; i++) {
            if (levelButtons[i].tag.Equals ("playbutton")) {
                int idx = Int32.Parse (levelButtons[i].name);
                if (idx > levelReached) {
                    Debug.Log ("lock: " + idx);
                    levelButtons[i].interactable = false;
                }
            }
        }
    }

    public void Select (string levelName) {
        Debug.Log ("Enter: " + levelName);
        SceneManager.LoadScene (levelName);
    }

    public void OnPointerClick (PointerEventData eventData) {
        tap = eventData.clickCount;
        Debug.Log ("Tap: " + tap);
        if (tap == 3) {
            UnLockAllLevel ();
        }
    }

    private void UnLockAllLevel () {
        for (int i = 0; i < levelButtons.Length; i++) {
            if (levelButtons[i].tag.Equals ("playbutton")) {
                levelButtons[i].interactable = true;
            }
        }
    }

}