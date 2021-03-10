using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    public void OnMouseDown () {
        Debug.Log ("restart current level");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
}