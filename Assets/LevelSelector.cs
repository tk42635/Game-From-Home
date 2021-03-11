using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    public Button[] levelButtons;

    void Start () {
        int levelReached = PlayerPrefs.GetInt ("", 1);
        for (int i = 0; i < levelButtons.Length; i++) {
            if (i + 1 > levelReached) {
                //levelButtons[i].interactable = false;
            }
        }
    }

    public void Select (string levelName) {
        Debug.Log ("Enter: " + levelName);
        SceneManager.LoadScene (levelName);
    }
}