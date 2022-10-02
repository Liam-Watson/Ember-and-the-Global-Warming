using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberDash : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public float selfDamage = 10f;

    public GameObject ps;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {   
        var prevVel = rb.velocity;
        var prevGrav = rb.gravityScale;
        if(direction == 0 && Input.GetKeyDown(KeyCode.LeftShift)){
            if(Input.GetAxisRaw("Horizontal") > 0){
                direction = 1;
                // rb.gravityScale = 0;
                // ps.GetComponent<ParticleSystem>().transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
                Instantiate(ps, transform.position, Quaternion.Euler(new Vector3(0f, 180f, 0f)));
                GetComponent<EmberGeneral>().TakeDamage(selfDamage);
            }else if(Input.GetAxisRaw("Horizontal") < 0){
                direction = -1;
                // rb.gravityScale = 0;
                
                Instantiate(ps, transform.position, Quaternion.identity);
                GetComponent<EmberGeneral>().TakeDamage(selfDamage);
            }else{
                if(prevVel.x > 0){
                    direction = 1;
                    Instantiate(ps, transform.position, Quaternion.identity);
                    GetComponent<EmberGeneral>().TakeDamage(selfDamage);
                    // rb.gravityScale = 0;
                }else if(prevVel.x < 0){
                    direction = -1;
                    Instantiate(ps, transform.position, Quaternion.identity);
                    GetComponent<EmberGeneral>().TakeDamage(selfDamage);
                    // rb.gravityScale = 0;
                }
            }
        } else{
            if(dashTime <= 0){
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = prevVel;
                rb.gravityScale = prevGrav;
            } else{
                dashTime -= Time.deltaTime;
                if(direction == 1){
                    rb.velocity = Vector2.right * dashSpeed;
                } else if(direction == -1){
                    rb.velocity = Vector2.left * dashSpeed;
                }
            }
        }
    }
}