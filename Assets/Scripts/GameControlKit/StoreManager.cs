using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LevelManager;

public class StoreManager : MonoBehaviour {
    private int coins;
    public bool[] haveItem;
    public int[] price = { 2, 3, 2, 4, 1, 1 };
    public string[] buttonName = { "Protector", "Magic Filler", "Collector", "Magnet", "One-Time Diamond", "Size Changer" };
    public Button[] itemButtons;
    public GameObject Label, Label2;
    public static Text text;

    // Start is called before the first frame update
    void Start () {
        coins = PlayerPrefs.GetInt ("Coins", 0);
        itemButtons = FindObjectsOfType<Button> ();
        haveItem = new bool[6];
        for (int i = 0; i < 6; i++) {
            haveItem[i] = (PlayerPrefs.GetInt ("Item_" + i, 0) == 1);
            if (haveItem[i]) {
                GameObject.Find (buttonName[i]).GetComponent<Button> ().interactable = false;
                float x = GameObject.Find (buttonName[i]).transform.position.x;
                float y = GameObject.Find (buttonName[i]).transform.position.y;
                Instantiate (Label, new Vector3 (x, y, 0), Quaternion.Euler(new Vector3(0, 0, 30)));
                }
        }
        text = GameObject.Find ("Coins").GetComponent<Text> ();
        GameObject mf = GameObject.Find ("Magic Filler");
        float mf_x = mf.transform.position.x;
        float mf_y = mf.transform.position.y;
        mf.GetComponent<Button> ().interactable = false;
        GameObject sc = GameObject.Find ("Size Changer");
        float sc_x = sc.transform.position.x;
        float sc_y = sc.transform.position.y;
        sc.GetComponent<Button> ().interactable = false;
        Instantiate (Label2, new Vector3 (mf_x, mf_y, 0), Quaternion.Euler(new Vector3(0, 0, 30)));
        Instantiate (Label2, new Vector3 (sc_x, sc_y, 0), Quaternion.Euler(new Vector3(0, 0, 30)));
    }

    // Update is called once per frame
    void Update () {
        text.text = ": " + coins;
    }

    public void Purchase (int id) {
        GameObject tmp = EventSystem.current.currentSelectedGameObject;
        Button btn = tmp.GetComponent<Button> ();
        if (coins >= price[id]) {
            coins -= price[id];
            haveItem[id] = true;
            PlayerPrefs.SetInt ("Coins", coins);
            PlayerPrefs.SetInt ("Item_" + id, 1);
            btn.interactable = false;
            float x = tmp.transform.position.x;
            float y = tmp.transform.position.y;
            Instantiate (Label, new Vector3 (x, y, 0), Quaternion.Euler(new Vector3(0, 0, 30)));
            Debug.Log ("Successful to purchase");
        } else {
            Debug.Log ("Failed to purchase");
        }
    }

    public void NextLevel () {
        int nextlevel = PlayerPrefs.GetInt ("CurLevel", 1) + 1;
        if (nextlevel <= LevelManager.maxlevel)
            SceneManager.LoadScene (nextlevel.ToString ());
        else
            SceneManager.LoadScene ("Menu");
    }
}