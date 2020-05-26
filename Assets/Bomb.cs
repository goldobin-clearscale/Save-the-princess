using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombObject;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D col) {
       if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("ground and platforms")) {
          Destroy(bombObject, 0.2f);  //This will destroy the pressure plate after it has been triggered 
      }
    }
}
