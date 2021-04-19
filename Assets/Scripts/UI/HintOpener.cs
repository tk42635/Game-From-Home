using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            if (Panel.activeSelf)
            {
                Panel.SetActive(false);
                Debug.Log("is not active");
                
            } else
            {
                Panel.SetActive(true);
                Debug.Log("is active");

            }
            
        }
    }
}
