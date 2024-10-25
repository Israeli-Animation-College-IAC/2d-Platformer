using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private bool _isGrounded = false;
    private Rigidbody2D _rigidbody2D;
    public float jumpForce = 5;
    public float horizontalMoveFactor = 6.0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Floor"))
         {
             _isGrounded = true;
             Debug.Log("Player has landed.");
         }
     }
 
     void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Floor"))
         {
             _isGrounded = false;
             Debug.Log("Player is in the air.");
         }
     }

     private void Update()
     {   
         if (_isGrounded && Input.GetButtonDown("Jump"))
         {
             _rigidbody2D.velocity = new Vector2(0, jumpForce);
         }
         float horizontal = Input.GetAxis("Horizontal");
         _rigidbody2D.velocity = new Vector2(horizontal * horizontalMoveFactor, _rigidbody2D.velocity.y);
     }
}
