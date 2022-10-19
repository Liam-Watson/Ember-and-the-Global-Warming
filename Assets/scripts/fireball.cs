using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody2D rb;
    private Vector3 worldPositionMouse;
    public GameObject Ember;

    public float healthGainOnKill;
    // Start is called before the first frame update
    void Start()
    {
        // Vector3 mousePos = Input.mousePosition;
        // mousePos.z = Camera.main.nearClipPlane;
        // worldPositionMouse = Camera.main.ScreenToWorldPoint(mousePos);
        rb = GetComponent<Rigidbody2D>();
        // Ember = GameObject.Find("Ember");
        var ePosX = Ember.GetComponent<Rigidbody2D>().position.x;
        var ePosY = Ember.GetComponent<Rigidbody2D>().position.y;
        // var ePos3D = new Vector3(ePosX, ePosY, 0); 
        // // rb.AddForce(((worldPositionMouse - Camera.main.transform.position + Camera.main.WorldToViewportPoint(ePos3D)).normalized ) * speed , ForceMode2D.Impulse);
        // rb.AddForce((((worldPositionMouse - Camera.main.transform.position).normalized - Camera.main.WorldToViewportPoint(ePos3D).normalized).normalized ) * speed , ForceMode2D.Impulse);
        Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
        Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
        // rb.AddForce(direction * speed, ForceMode2D.Impulse);
        rb.velocity = direction * speed ;//+ speed*(new Vector2(Ember.GetComponent<Rigidbody2D>().velocity.x, Ember.GetComponent<Rigidbody2D>().velocity.y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "block" && collision.gameObject.tag != "boundary"){
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetBool("isDead", true);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject, 1.1f);
            Destroy(gameObject);
            Ember.GetComponent<EmberGeneral>().TakeDamage(-1*healthGainOnKill);
        }else if(collision.gameObject.tag == "block"){
            Destroy(gameObject);
            // Physics2D.IgnoreCollision(Ember.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "block" && collision.gameObject.tag != "boundary"){
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetBool("isDead", true);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject, 1.1f);
            Destroy(gameObject);
            Ember.GetComponent<EmberGeneral>().TakeDamage(-1*healthGainOnKill);
        }else if(collision.gameObject.tag == "block"){
            Destroy(gameObject);
            // Physics2D.IgnoreCollision(Ember.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }
}
