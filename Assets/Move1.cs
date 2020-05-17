using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public enum state { ground, jump_start, jump_middle, jump_end}

public class Move1 : MonoBehaviour
{
	state anim_state = state.ground;
    bool isFaceRight = true;
    // UnityArmatureComponent armatureComponent = GetComponent<UnityArmatureComponent> ();
    Rigidbody2D rb;
    UnityArmatureComponent myArmature;
    // Start is called before the first frame update

    string currentAnimation = "idol";
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        myArmature = GetComponent<UnityArmatureComponent>();
        myArmature.animation.Play("State");
        // myArmature.animation.Play("State");
    }

    // Update is called once per frame
    void Update()
    {
        // myArmature.animation.Play("run"); 
        if (Input.GetKeyDown(KeyCode.Space) && currentAnimation != "jump")
        {
            Jump();
			//StartCoroutine(Jump());
        }
		Check_State();
		if (Input.GetAxis("Horizontal") != 0)
		{
			Flip();
		}
		if (anim_state != state.ground) return;
		if (Input.GetAxis("Horizontal") == 0){
            //run animation when staying
            if(currentAnimation != "Idol"){
                currentAnimation = "Idol";
				myArmature.animation.FadeIn("Idol", 0.05f, -1);
            }
            
        }
        else {
            //when staying 
            if(currentAnimation != "run"){
                currentAnimation = "run";
				myArmature.animation.FadeIn("run", 0.05f, -1);
            }  
            //Flip();
        }
        
    }

	void Check_State()
	{
		switch (anim_state) {
			case state.ground:
				{
					return;
				}
			case state.jump_start:
				{
					if (rb.velocity.y < 0)
					{
						myArmature.animation.FadeIn("jump_middle", 0.05f, 1);
						anim_state = state.jump_middle;
						Debug.Log("sw_1");
					}
					break;
				}
			case state.jump_middle:
				{
					if (Mathf.Abs(rb.velocity.y) <= 1f)
					{
						// myArmature.animation.FadeIn("jump_end", 0.25f, 1);
						anim_state = state.jump_end;
						Debug.Log("sw_2");
					}
					break;
				}
			case state.jump_end:
				{
					if (myArmature.animation.isCompleted)
					{
						Debug.Log("sw_3");
						anim_state = state.ground;
					}
					break;
				}
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
		Debug.Log("jump");
        // myArmature.animation.FadeIn("State", 0.025f, 0, 1);
        currentAnimation = "jump";
        myArmature.animation.FadeIn("jump_start", 0.05f, 1);
        rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);
		anim_state = state.jump_start;
		// myArmature.animation.FadeIn("stand2", 0.05f, -1, 0);
	}

	//IEnumerator Jump()
	//{
	//	Debug.Log("jump");
	//	// myArmature.animation.FadeIn("State", 0.025f, 0, 1);
	//	currentAnimation = "jump";
	//	myArmature.animation.FadeIn("jump_start", 0.05f, 1);
	//	yield return new WaitForSeconds(0.1f);
	//	rb.AddForce(transform.up * 11f, ForceMode2D.Impulse);
	//	anim_state = state.jump_start;
	//	// myArmature.animation.FadeIn("stand2", 0.05f, -1, 0);
	//}
}
