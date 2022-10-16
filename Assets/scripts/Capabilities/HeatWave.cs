using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatWave : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform ember;
    private Rigidbody2D emberRidgidbody;
    public GameObject ps;

    public GameObject soundEffect;

    public float selfDamage;
    void Start()
    {
        ember = GetComponent<Transform>();
        emberRidgidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && !PauseMenu.gameIsPaused){
            //Play Animation 
            GameObject Ember = GameObject.Find("Ember");
            Animator animator = Ember.GetComponent<Animator>();
            Debug.Log(animator);
            animator.SetBool("Wave_Attack", true);
            
            Invoke("InstantiatePSandSound", 0.5f);
        
            //Damage ember
            GetComponent<EmberGeneral>().TakeDamage(selfDamage);
        }

    }
    void InstantiatePSandSound(){
        ps.GetComponent<Transform>().position = ember.position;
        Instantiate(ps, ember.position, Quaternion.Euler(new Vector3(-90f, 0f, 0f)));
        Instantiate(soundEffect, ember.position, Quaternion.identity);
    }

    
}
