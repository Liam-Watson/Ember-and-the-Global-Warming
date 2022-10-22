using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets the behaviour of Ember's projectile, the fireball
public class fireball : MonoBehaviour
{
    public float speed = 20;
    public GameObject Ember ;
    public float healthGainOnKill;

    private Rigidbody2D rb;
    private Vector3 worldPositionMouse;
    // Start is called before the first frame update
    void Start()
    {
        // Set the direction and speed of the projectile upon spawn
        rb = GetComponent<Rigidbody2D>();
        Ember = GameObject.Find("Ember");
        var ePosX = Ember.GetComponent<Rigidbody2D>().position.x;
        var ePosY = Ember.GetComponent<Rigidbody2D>().position.y;
        Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
        Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
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
        }
        
    }
}
