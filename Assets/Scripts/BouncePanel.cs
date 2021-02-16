using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePanel : MonoBehaviour
{
    const float x_base = -9f,
		y_base = -5f;
	const float step = 0.1f;
    const int force = 8;
    //public GameObject bouncepanel_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void SpawnPanel (float x, float y, float angle) {
	// 	GameObject holder_Obj;

    //     Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

	// 	holder_Obj = Instantiate (bouncepanel_Prefab, new Vector3 (x, y, 0f), rotation);
	// 	holder_Obj.name = "bouncepanel_" + x + "_" + y;
		
	// }
    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        int x = Mathf.RoundToInt((other.transform.position.x - x_base) / step);
        int y = Mathf.RoundToInt((other.transform.position.y - y_base) / step);
        int r = Mathf.RoundToInt(other.transform.rotation.z);

        // int end_x = Mathf.RoundToInt(other.transform.position.x - 4 * Mathf.Cos(2f * Mathf.PI / 180 * r));
        // int end_y = Mathf.RoundToInt(other.transform.position.y - 4 * Mathf.Sin(2f * Mathf.PI / 180 * r));
        int end_x = x + 60;
        int end_y = y;

        GameObject.Find("HolderSpawner").GetComponent<HolderSpawner>().EraseLine(x, y, end_x, end_y);

        Rigidbody2D RIG = other.GetComponent<Rigidbody2D>();
        RIG.velocity = new Vector3(0,0,0);
        RIG.AddForce(new Vector3 (5, 0, 0), ForceMode2D.Impulse);

        Debug.Log((x, y));

        // Destroy(gameObject);
    }
}
