using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets the behaviour of the Fireman's projectile
public class firemanProj : MonoBehaviour
{
    public float speed;
    public GameObject ps;

    private Transform ember;
    private Vector2 target;

    public float damage;

    public GameObject foamSoundEffect;

    public GameObject emberDamageSF;

    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember").transform;
        target = new Vector2(ember.position.x, ember.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Performs a transform from the spawning point to embers current position at a certain speed
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            // Destroys the gameObject this script is attached to once it reaches its destination
            DestroyProj();
        }

        Instantiate(ps, transform.position, Quaternion.identity);
        ps.GetComponent<ParticleSystem>().Play();
    }
    
    // Checks whether it collides with Ember, plays sound effects if it does
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(emberDamageSF, transform.position, Quaternion.identity);
            emberDamageSF.GetComponent<AudioSource>().Play();
            DestroyProj();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ember.GetComponent<EmberGeneral>().TakeDamage(damage);
            Instantiate(emberDamageSF, transform.position, Quaternion.identity);
            emberDamageSF.GetComponent<AudioSource>().Play();
            DestroyProj();
        }
        
    }

    void DestroyProj()
    {
        Destroy(gameObject);
    }

    // Plays certain sound effects when awake
    private void Awake() {
        Instantiate(foamSoundEffect, transform.position, Quaternion.identity);
        foamSoundEffect.GetComponent<AudioSource>().Play();
    }
}
