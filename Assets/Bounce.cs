using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
   void onCollisionEnter2D(Collision collision) {
       Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
   }
}
 