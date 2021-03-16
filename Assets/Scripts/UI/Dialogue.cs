using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    public GameObject Diamond;
    public GameObject DiamondNotGet;
    public GameObject DiamondsLayout;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start () {
        int DiamondNotGetNum = levelManager.getRequiredScore() - levelManager.getScore();
        Debug.Log ("Dialog Start");
        levelManager = FindObjectOfType<LevelManager> ();
        int DiamondGetNum = levelManager.getScore ();
        for (int i = 0; i < DiamondGetNum; i++) {
            GameObject NewDiamond = Instantiate (Diamond, transform.position, transform.rotation);
            NewDiamond.transform.parent = DiamondsLayout.transform;
        }
        for (int i = 0; i < DiamondNotGetNum; i++) {
            GameObject NewDiamondNotGet = Instantiate (DiamondNotGet, transform.position, transform.rotation);
            NewDiamondNotGet.transform.parent = DiamondsLayout.transform;
        }
        gameObject.SetActive (true);
    }

    // Update is called once per frame
    void Update () {

    }

    public void onShow () {
        Debug.Log ("Dialog OnShow");
        gameObject.SetActive (true);
    }
    public void onRetry () {
        Debug.Log ("Dialog OnRetry");
        gameObject.SetActive (false);
    }
    public void onContinue () {
        gameObject.SetActive (false);
    }

    public void Reset () {
        Debug.Log ("Dialog reset");
    }

}