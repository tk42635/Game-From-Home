using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    public int maxlevel = 2;
    public void OnMouseDown () {
        Debug.Log ("go to next level");
        int thislevel = int.Parse (SceneManager.GetActiveScene ().name);
        int nextlevel = thislevel + 1;
        if (nextlevel <= maxlevel)
            SceneManager.LoadScene (nextlevel.ToString ());
        else
            SceneManager.LoadScene ("Menu");
    }
}