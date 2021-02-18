using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    private LevelOneManager levelOneManager;
    // define the value of element
    public int diamondValue = 1;


    // Start is called before the first frame update
    void Start()
    {
        levelOneManager = FindObjectOfType<LevelOneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // need to change the tag of the element
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            levelOneManager.AddScore(diamondValue);
        }
    }
}
