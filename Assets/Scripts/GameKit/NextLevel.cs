using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("go to next level");
        SceneManager.LoadScene("Stage2");
    }
}
