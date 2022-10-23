using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ember's main attack which shots in direction of the cursor
public class attack : MonoBehaviour
{
    public Transform projPos;
    public GameObject fireball;
    public float selfDamage;
    public EmberGeneral ember;
    public GameObject soundEffect;

    private Vector3 worldPositionMouse;
    private  GameObject fireballObj;

    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember").GetComponent<EmberGeneral>();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        // Get input from player
        if (Input.GetMouseButtonDown(0) && !PauseMenu.gameIsPaused)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPositionMouse = Camera.main.ScreenToWorldPoint(mousePos);
            
            // Get character position
            Vector3 charPos = transform.position;
            
            if (worldPositionMouse.x < charPos.x){
                fireballObj = Instantiate(fireball, (charPos), projPos.rotation);
                Instantiate(soundEffect, charPos, Quaternion.identity);
                ember.TakeDamage(selfDamage);
            }else{
                fireballObj = Instantiate(fireball, charPos, projPos.rotation);
                Instantiate(soundEffect, charPos, Quaternion.identity);
                ember.TakeDamage(selfDamage);
            }
            Physics2D.IgnoreCollision(fireballObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            

        }
        //if input is attack

    }
    
}
