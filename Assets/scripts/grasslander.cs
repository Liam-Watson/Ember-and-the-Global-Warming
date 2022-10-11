using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grasslander : MonoBehaviour
{
    public GameObject blade;
    public float range;
    public float fireRate;

    public Animator animator;

    private GameObject ember;
    private Vector3 currentPos;
    private GameObject grassBlade;
    private float shotTime;

    public float healthGainOnKill;

    // Start is called before the first frame update
    void Start()
    {
        ember = GameObject.Find("Ember");
        currentPos = transform.position;
        shotTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        float emberX = ember.transform.position.x;
        float emberY = ember.transform.position.x;

        Vector2 grass = new Vector2(currentPos.x, currentPos.y);
        Vector2 emb = new Vector2(emberX, emberY);
        float dist = Vector2.Distance(emb, grass);

        if (shotTime <= 0 && dist <= range)
        {
            grassBlade = Instantiate(blade, currentPos, Quaternion.identity);
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
            Destroy(gameObject, 1.1f);
            ember.GetComponent<EmberGeneral>().TakeDamage(-1*healthGainOnKill);
        }
    }
}
