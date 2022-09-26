using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emberMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask blockLayerMask;
    private float emberSpeed = 15.0f;
    private float jumpPower = 20.0f;
    private BoxCollider2D boxCollider2d;

    private Rigidbody2D emberRB;
    void Start()
    {
        emberRB = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        MovePlayer();
        if (Input.GetKey(KeyCode.Space) && IsGrounded() ){
            Jump();
        }
        
    }

    private void Jump(){
        emberRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + 0.1f, blockLayerMask);
        return hit.collider != null;
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        emberRB.velocity = new Vector2(horizontalInput * emberSpeed, emberRB.velocity.y);
    }
}
