using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BagManager : MonoBehaviour {
    // Start is called before the first frame update
    // private GameObject Bag;
    public GameObject BagDialogue;
    public GameObject[] BagElement;
    public Dictionary<int, Vector3> loc = new Dictionary<int, Vector3> () { { 0, new Vector3 (-230, 200, 0) }, { 1, new Vector3 (0, 200, 0) }, { 2, new Vector3 (230, 200, 0) }, { 3, new Vector3 (-230, -200, 0) }, { 4, new Vector3 (0, -200, 0) }, { 5, new Vector3 (230, -200, 0) },
    };
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void OnMouseDown () {
        if (!EventSystem.current.IsPointerOverGameObject ())
            CreateBag ();
    }

    public void CreateBag () {
        Debug.Log ("Bag");
        float mainCameraY = GameObject.Find ("Main Camera").transform.position.y;
        var Bag = (GameObject) Instantiate (BagDialogue, new Vector3 (0, mainCameraY, 0), Quaternion.identity);
        GameObject.Find ("HolderSpawner").GetComponent<HolderSpawner> ().Disable ();
        Bag.name = "BagDialogue";

        bool[] haveItem = new bool[6];
        for (int i = 0; i < 6; i++)
            haveItem[i] = (PlayerPrefs.GetInt ("Item_" + i, 0) == 1);
        for (int i = 0, cur = 0; i < 6; i++) {
            if (haveItem[i]) {
                loc[cur].Set(loc[cur].x, loc[cur].y + mainCameraY, loc[cur].z);
                var tmp = Instantiate (BagElement[i], loc[cur], Quaternion.identity);
                tmp.transform.SetParent (Bag.transform, false);
                cur++;
            }
        }

        //GameObject.DestroyImmediate (Bag);

    }

    public void Close () {
        Debug.Log ("Close");
        var tmp = GameObject.Find ("BagDialogue");
        GameObject.DestroyImmediate (tmp);
        GameObject.Find ("HolderSpawner").GetComponent<HolderSpawner> ().Enable ();
    }

}