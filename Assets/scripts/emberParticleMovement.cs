using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the behaviour of Ember's particles
public class emberParticleMovement : MonoBehaviour
{
    public float moveSpeed;

    private Transform playerPos;
    private Transform pos;
    private ParticleSystem ps;
    private GameObject Ember;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Background";
        
        Ember = GameObject.Find("Ember");

        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find ("Ember").transform;
        var playerVelocity = Ember.GetComponent<Rigidbody2D>().velocity;
        pos.position = new Vector3(playerPos.position.x, playerPos.position.y, -0.1f);
        
        ps = GetComponent<ParticleSystem>();
        var module = ps.velocityOverLifetime;
        module.x = new ParticleSystem.MinMaxCurve(-playerVelocity.x);
        module.z = new ParticleSystem.MinMaxCurve(-playerVelocity.y);
    }
}
