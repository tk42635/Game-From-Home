using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    
    // Start is called before the first frame update
    void Start()
    {
        coins = 10;
        itemButtons = FindObjectsOfType<Button> ();
        haveItem = new bool[6];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void purchase(int id)
    {
        Button btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if(coins >= price[id])
        {
            coins -= price[id];
            haveItem[id] = true;
            btn.interactable = false;
            Debug.Log ("Successful to purchase");
        }
        else
        {
            Debug.Log ("Failed to purchase");
        }
    }
}
