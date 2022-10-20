using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberGeneral : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public EmberHeat heatBar;

    private Animator animator;

    private GameObject ember;



    // Start is called before the first frame update
    void Start()
    {
        heatBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        ember = GameObject.Find("Ember");
        animator = ember.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Transform>().position.y <= -80f)
        {
            currentHealth = 0f;
        }
    }

    private void FixedUpdate() {
    //    
        TakeDamage(0.01f);
    }

    //Subtract health over time
    public void  TakeDamage(float damage){
        currentHealth -= damage;
        if((currentHealth) > maxHealth){
            currentHealth = maxHealth;
        }
        
        
        if (currentHealth <= 0){
            GameObject ember = GameObject.Find("Ember");
            
            animator.SetBool("isDead", true);
            // Destroy(ember, 1.3f);
            StartCoroutine(MovePlayerAfterDeath());
            
            // Destroy(gameObject);
            // Destroy(GameObject.Find("Ember"));
        }
        // Debug.Log(currentHealth);
        heatBar.SetHealth(currentHealth);
    }

    IEnumerator MovePlayerAfterDeath() {
     yield return new WaitForSeconds(1.3f);
     transform.position = new Vector2(0, 0.9149879f);
     currentHealth = maxHealth;
     animator.SetBool("isDead", false);
     Application.LoadLevel(Application.loadedLevel);
 }
}
