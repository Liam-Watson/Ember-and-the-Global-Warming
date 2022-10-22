using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the position of the custom cursor
public class Custom_Cursor : MonoBehaviour
{
    public float adjust_x = 40;
    public float adjust_y = 40;
    public bool crosshair = false;

    private float x, y;

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
