using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberGeneral : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public EmberHeat heatBar;

    // Start is called before the first frame update
    void Start()
    {
        heatBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
    //    
        TakeDamage(0.01f);
    }

    //Subtract health over time
    public void  TakeDamage(float damage){
        currentHealth -= damage;
        
        if (currentHealth <= 0){
            GameObject ember = GameObject.Find("Ember");
            Animator animator = ember.GetComponent<Animator>();
            animator.SetBool("isDead", true);
            Destroy(ember, 1.3f);
            // Destroy(gameObject);
            // Destroy(GameObject.Find("Ember"));
        }
        // Debug.Log(currentHealth);
        heatBar.SetHealth(currentHealth);
    }
}
