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
            Destroy(GameObject.Find("Ember"));
        }
        Debug.Log(currentHealth);
        heatBar.SetHealth(currentHealth);
    }
}
