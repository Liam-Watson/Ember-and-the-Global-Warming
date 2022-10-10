using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatWave : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ember;
    private Rigidbody2D emberRidgidbody;
    public GameObject ps;

    public float selfDamage;
    void Start()
    {
        ember = GetComponent<Transform>();
        emberRidgidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            ps.GetComponent<Transform>().position = ember.position;
            Instantiate(ps, ember.position, Quaternion.Euler(new Vector3(-90f, 0f, 0f)));
            
            // ps.GetComponent<ParticleSystem>().Play();
            //Damage ember
            GetComponent<EmberGeneral>().TakeDamage(selfDamage);
        }
    }
}
