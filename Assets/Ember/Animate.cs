using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shinjingi{
    public class Animate : MonoBehaviour
    {
        // Start is called before the first frame update

        public Animator animator;

        private Rigidbody2D _body;
        void Start()
        {
            
        }
        private void Awake()
            {
                _body = GetComponent<Rigidbody2D>();
            }

        // Update is called once per frame
        void Update()
        {
            // if (Input.GetKeyDown(KeyCode.Space)){
            //     animator.SetBool("Space_Pressed", true);
            // }else{
            //     animator.SetBool("Space_Pressed", false);
            // }
        }
        void FixedUpdate(){
            // Debug.Log(Input.GetMouseButtonDown(1));
            if(Input.GetMouseButtonDown(1)){
                animator.SetBool("Wave_Attack", true);
                
                
                
            }else{
                animator.SetBool("Wave_Attack", false);
                animator.SetFloat("Speed", Mathf.Min(1, Mathf.Abs(_body.velocity.x/10)));
                animator.SetFloat("X", Input.GetAxis("Horizontal"));
                animator.SetFloat("Y", _body.velocity.y);
            }
            
        }
    }
}
    
