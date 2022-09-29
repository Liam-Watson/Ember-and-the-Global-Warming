using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject ps;
    public Rigidbody2D emberRB;
    // public 
    // Start is called before the first frame update
    void Start()
    {
        emberRB = GameObject.Find("Ember").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            ps = Instantiate(ps, emberRB.position, Quaternion.identity);
            ParticleSystem  ps2 = ps.GetComponent<ParticleSystem>();
            ps2.Play();
        }
    }
}
