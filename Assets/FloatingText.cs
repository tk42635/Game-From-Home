using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouse_over = false;
    private bool pre_status = false;
    public GameObject TextFrame;
    private GameObject tmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pre_status && mouse_over)
        {
            tmp = Instantiate (TextFrame, new Vector3 (0, 0, 0), Quaternion.identity);
            pre_status = mouse_over;
        }
        else if(pre_status && !mouse_over)
        {
            Destroy(tmp);
            pre_status = mouse_over;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
    }
}
