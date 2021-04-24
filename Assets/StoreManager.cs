using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LevelManager;

public class StoreManager : MonoBehaviour
{
    private int coins;
    public bool[] haveItem;
    public int[] price = {2, 3 ,2 ,4 ,1 ,1};
    public Dictionary<string, int> buttonName = new Dictionary<string, int>(){
        {"Protector", 0},
        {"Magic Fillor", 1},
        {"Collector", 2},
        {"Magnet", 3},
        {"One-Time Diamond", 4},
        {"Size Changer", 5},
    };
    public Button[] itemButtons;
    public static Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt ("Coins", 0);
        itemButtons = FindObjectsOfType<Button> ();
        haveItem = new bool[6];
        for(int i = 0; i <6; i++)
            haveItem[i] = (PlayerPrefs.GetInt ("Item_" + i, 0) == 1);
        text = GameObject.Find("Coins").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "you have " + coins;
    }

    public void Purchase(int id)
    {
        Button btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if(coins >= price[id])
        {
            coins -= price[id];
            haveItem[id] = true;
            PlayerPrefs.SetInt ("Item_" + id, 1);
            btn.interactable = false;
            Debug.Log ("Successful to purchase");
        }
        else
        {
            Debug.Log ("Failed to purchase");
        }
    }

    public void NextLevel()
    {
        int nextlevel = PlayerPrefs.GetInt ("CurLevel", 1) + 1;
        if (nextlevel <= LevelManager.maxlevel)
            SceneManager.LoadScene (nextlevel.ToString ());
        else
            SceneManager.LoadScene ("Menu");
    }
}
