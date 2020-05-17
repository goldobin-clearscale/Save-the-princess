using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Move : MonoBehaviour
{

    bool isFaceRight = true;
    // UnityArmatureComponent armatureComponent = GetComponent<UnityArmatureComponent> ();
    Rigidbody2D rb;
    UnityArmatureComponent myArmature;
    // Start is called before the first frame update

    string currentAnimation = "State";
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        myArmature = GetComponent<UnityArmatureComponent>();
        // myArmature.animation.Play("State");
        // myArmature.animation.Play("State");
    }

    // Update is called once per frame
    void Update()
    {
        // myArmature.animation.Play("run"); 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); 
        }
        if(Input.GetAxis("Horizontal") == 0){
            //run animation when staying
            if(currentAnimation != "State"){
                currentAnimation = "State";
                myArmature.animation.Play("State");
            }
            
        }
        else {
            //when staying 
            if(currentAnimation != "run"){
                currentAnimation = "run";
                myArmature.animation.Play("run");
            }  
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
        // myArmature.animation.FadeIn("State", 0.025f, 0, 1);
        currentAnimation = "jump";
        myArmature.animation.FadeIn("jump", 0.1f, 0, 1);
        rb.AddForce(transform.up * 11f, ForceMode2D.Impulse);
        // myArmature.animation.FadeIn("stand2", 0.05f, -1, 0);
    }
}
