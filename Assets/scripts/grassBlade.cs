using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassBlade : MonoBehaviour
{
    public float speed;
    public GameObject ps;

    private Transform ember;
    private Vector2 target;

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
            DestroyBlade();
        }

        Instantiate(ps, transform.position, Quaternion.identity);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBlade();
        }
    }

    void DestroyBlade()
    {
        Destroy(gameObject);
    }
}
