using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the attacking, health and sounds of the Fireman
public class fireman : MonoBehaviour
{
    public GameObject proj;
    public float range;
    public float fireRate;
    public float healthGainOnKill;
    public Animator animator;

    private GameObject ember;
    private Vector3 spawnPos;
    private GameObject firemanProj;
    private float shotTime;


    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember");
        spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        shotTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        float emberX = ember.transform.position.x;
        float emberY = ember.transform.position.y;

        Vector2 fireman = new Vector2(transform.position.x, transform.position.y);
        Vector2 emb = new Vector2(emberX, emberY);
        float dist = Vector2.Distance(emb, fireman);

        // Checking whether ember is in range and enough time has passed
        if (shotTime <= 0 && dist <= range)
        {
            firemanProj = Instantiate(proj, spawnPos, Quaternion.identity);
            shotTime = fireRate;
        }
        // Otherwise subtracting current time to keep track of the firerate
        else 
        {
            shotTime -= Time.deltaTime;
        }
    }

    private void OnParticleCollision(GameObject other) {
        // Checks whether it has been hit by one of Ember's attacks
        if(other.gameObject.tag == "heatwave"){
            animator.SetBool("isDead", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1.1f);
            // Adding health to ember for killing
            ember.GetComponent<EmberGeneral>().TakeDamage(-1*healthGainOnKill);
        }
    }
}
