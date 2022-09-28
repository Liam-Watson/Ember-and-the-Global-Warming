using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatWaveParticles : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public GameObject Ember;
    private Transform pos;
    public float selfDamage;
    // private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        collisionParticleSystem = GetComponent<ParticleSystem>();
        pos = GetComponent<Transform>();
        Ember = GameObject.Find("Ember");
        // playerPos = Ember.GetComponent<Rigidbody2D>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            collisionParticleSystem.Play();
            //Damage ember
            Ember.GetComponent<EmberGeneral>().TakeDamage(selfDamage);
        }
    }
    void DestroyObject(){
        Destroy(gameObject);
    }
}
