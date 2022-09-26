﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;
    private Vector3 worldPositionMouse;
    public GameObject Ember;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPositionMouse = Camera.main.ScreenToWorldPoint(mousePos);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(worldPositionMouse * speed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }else{
            // Physics2D.IgnoreCollision(Ember.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }else{
            // Physics2D.IgnoreCollision(Ember.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }
}
