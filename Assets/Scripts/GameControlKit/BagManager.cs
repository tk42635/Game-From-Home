using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BagManager : MonoBehaviour
{
    // Start is called before the first frame update
    // private GameObject Bag;
    public GameObject BagDialogue;
    public GameObject[] BagElement;
    public Dictionary<int, Vector3> loc = new Dictionary<int, Vector3>(){
        {0, new Vector3(-180, 150, 0)},
        {1, new Vector3(0, 150, 0)},
        {2, new Vector3(180, 150, 0)},
        {3, new Vector3(-180, -150, 0)},
        {4, new Vector3(0, -150, 0)},
        {5, new Vector3(180, -150, 0)},
    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown () {
        CreateBag();
    }

    public void CreateBag() {
        Debug.Log ("Bag");
        var Bag = (GameObject) Instantiate (BagDialogue, new Vector3 (0, 0, 0), Quaternion.identity);
        Bag.name = "BagDialogue";

        bool[] haveItem = new bool[6]; 
        for(int i = 0; i < 6; i++)
            haveItem[i] = (PlayerPrefs.GetInt ("Item_" + i, 0) == 1);
        for(int i = 0, cur = 0; i < 6; i++)
        {
            if(haveItem[i])
            {
                var tmp = Instantiate (BagElement[i], loc[cur], Quaternion.identity);
                tmp.transform.SetParent(Bag.transform, false);
                cur++;
            }
        }

        //GameObject.DestroyImmediate (Bag);
    

    }

    public void Close() {
        Debug.Log("Close");
        var tmp = GameObject.Find("BagDialogue");
        GameObject.DestroyImmediate (tmp);
    }

    
}
