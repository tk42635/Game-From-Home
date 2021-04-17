using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIce : MonoBehaviour
{
    private float min_X = -1.4f, max_X = 1.4f;
    private bool canMove;
    private float move_Speed = 2f;

    private bool firstTime;
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer> ();
        MoveIcePlatforms();
    }
    
    void MoveIcePlatforms(){
        if(canMove){
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;

            if(temp.x > max_X){
                move_Speed *= -1f;
            }else if(temp.x < min_X){
                move_Speed *= -1f;
            }
            transform.position = temp;

        }
    }
    void OnCollisionStay2D (Collision2D other) {
        Rigidbody2D RIG = other.gameObject.GetComponent<Rigidbody2D> ();
        // Debug.Log("Collision!");
        if (Mathf.Abs (RIG.velocity.x) < 0.1f) {
            if (other.transform.position.x >= gameObject.transform.position.x)
                RIG.velocity = new Vector3 (0.1f, 0, 0);
            else
                RIG.velocity = new Vector3 (-0.1f, 0, 0);
        }

    }

    void OnCollisionExit2D (Collision2D collision) {
        if (firstTime == true) {
            firstTime = false;
            m_SpriteRenderer.color = Color.gray;
        } else{
            canMove = false;
            Destroy (gameObject);
        }
            
    }
}
