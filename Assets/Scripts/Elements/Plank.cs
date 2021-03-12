using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D (Collision2D other) {
        Rigidbody2D RIG = other.gameObject.GetComponent<Rigidbody2D> ();
        // Debug.Log("Collision!");
        if(Mathf.Abs(RIG.velocity.x) < 0.1f)
            {if(other.transform.position.x >= gameObject.transform.position.x)
                RIG.velocity = new Vector3 (0.1f, 0, 0);
            else
                RIG.velocity = new Vector3 (-0.1f, 0, 0);}

    }
}
