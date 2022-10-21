using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodworker : MonoBehaviour
{
    public GameObject proj;
    public float range;
    public float fireRate;
    public Animator animator;

    private GameObject ember;
    private Vector3 spawnPos;
    private GameObject woodworkerProj;
    private float shotTime;

    public float healthGainOnKill;

    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember");
        spawnPos = new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z);
        shotTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        float emberX = ember.transform.position.x;
        float emberY = ember.transform.position.y;

        Vector2 grass = new Vector2(transform.position.x, transform.position.y);
        Vector2 emb = new Vector2(emberX, emberY);
        float dist = Vector2.Distance(emb, grass);

        if (shotTime <= 0 && dist <= range  && animator.GetBool("isDead") == false)
        {
            woodworkerProj = Instantiate(proj, spawnPos, Quaternion.identity);
            shotTime = fireRate;
        }
        else 
        {
            shotTime -= Time.deltaTime;
        }
    }

    private void OnParticleCollision(GameObject other) {
        if(other.gameObject.tag == "heatwave"){
            animator.SetBool("isDead", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1.1f);
            ember.GetComponent<EmberGeneral>().TakeDamage(-1*healthGainOnKill);
        }
    }
}
