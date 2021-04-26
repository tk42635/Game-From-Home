using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    public void OpenOptions () {
        SceneManager.LoadScene ("Option");
    }

    public void OpenStore () {
        SceneManager.LoadScene ("Store");
    }

    public void QuitGame () {
        Debug.Log ("Quit!");
        Application.Quit ();
    }
}