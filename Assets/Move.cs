﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    bool isFaceRight = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); 
        }
        if(Input.GetAxis("Horizontal") == 0){
            //run animation
            //  this.GetComponent<UnityArmatureComponent>().animation.Play("run");
        }
        else {
            Flip();
        }
        
    }

    void Flip(){
        if (Input.GetAxisRaw ("Horizontal") > 0.5f && !isFaceRight || Input.GetAxisRaw ("Horizontal") < -0.5f && isFaceRight){
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            isFaceRight = !isFaceRight;
        } 
    }

    void FixedUpdate () {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 6f, rb.velocity.y);
    }

    void Jump () {
        rb.AddForce(transform.up * 11f, ForceMode2D.Impulse);
    }
}
