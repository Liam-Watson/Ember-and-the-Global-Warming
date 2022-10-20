using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Cursor : MonoBehaviour
{
    private float x, y;
    public float adjust_x = 40;
    public float adjust_y = 40;
    public bool crosshair = false;
    void Start(){
        x = GetComponent<RectTransform>().rect.width;
        y = GetComponent<RectTransform>().rect.height;
    }
    
    void Update()
    {
        Vector2 cursorPs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(crosshair){
            // Debug.Log(x);
            cursorPs.x  = cursorPs.x - (x/adjust_x);
            cursorPs.y = cursorPs.y + (y/adjust_y);
            // Debug.Log(cursorPs.x);
        }
        
        transform.position = cursorPs;
        Cursor.visible = false;
    }
}
