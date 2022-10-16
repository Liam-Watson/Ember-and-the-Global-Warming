using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Transform projPos;
    public GameObject fireball;
    private Vector3 worldPositionMouse;
    private  GameObject fireballObj;
    public float selfDamage;
    public EmberGeneral ember;

    public GameObject soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember").GetComponent<EmberGeneral>();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        //get input from player
        if (Input.GetMouseButtonDown(0) && !PauseMenu.gameIsPaused)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPositionMouse = Camera.main.ScreenToWorldPoint(mousePos);
            //get character position
            Vector3 charPos = transform.position;
            
            if (worldPositionMouse.x < charPos.x){
                fireballObj = Instantiate(fireball, (charPos), projPos.rotation);
                Instantiate(soundEffect, charPos, Quaternion.identity);
                ember.TakeDamage(selfDamage);
                Debug.Log("left");
            }else{
                fireballObj = Instantiate(fireball, charPos, projPos.rotation);
                Instantiate(soundEffect, charPos, Quaternion.identity);
                ember.TakeDamage(selfDamage);
                Debug.Log("right");
            }
            Physics2D.IgnoreCollision(fireballObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            

        }
        //if input is attack

    }
    
}
