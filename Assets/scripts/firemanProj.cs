using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firemanProj : MonoBehaviour
{
    public float speed;
    public GameObject ps;

    private Transform ember;
    private Vector2 target;

    public float damage;

    public GameObject foamSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember").transform;
        target = new Vector2(ember.position.x, ember.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProj();
        }

        Instantiate(ps, transform.position, Quaternion.identity);
        ps.GetComponent<ParticleSystem>().Play();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProj();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ember.GetComponent<EmberGeneral>().TakeDamage(damage);
            DestroyProj();
        }
        
    }

    void DestroyProj()
    {
        Destroy(gameObject);
    }

    private void Awake() {
        Instantiate(foamSoundEffect, transform.position, Quaternion.identity);
        foamSoundEffect.GetComponent<AudioSource>().Play();
    }
}
