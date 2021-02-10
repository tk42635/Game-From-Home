using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneManager : MonoBehaviour
{
	public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "* " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int diamondValue) {
        score += diamondValue;
        scoreText.text = "* " + score; // UI on the screen
    }
}
