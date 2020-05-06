using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

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
        }
        else {
            Flip();
        }
        
    }

    void Flip(){
        if(Input.GetAxis("Horizontal") > 0){
            transform.localRotation = Quaternion.Euler (0, 0, 0);
        }
        if(Input.GetAxis("Horizontal") < 0) {
            transform.localRotation = Quaternion.Euler (0, 180, 0);
        }
    }

    void FixedUpdate () {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 6f, rb.velocity.y);
    }

    void Jump () {
        rb.AddForce(transform.up * 11f, ForceMode2D.Impulse);
    }
}
