using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPlayer : MonoBehaviour
{
    private GameObject[] respawn;
    public GameObject player;

    void Start () {
        
        if(respawn == null){
            gameObject.name = "test " + Time.realtimeSinceStartup;
            respawn = GameObject.FindGameObjectsWithTag("Respawn");
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
       if(col.gameObject.CompareTag("bomb")) {
           Dead();
      }
    }

    void Dead(){
       Destroy(player, 0.2f);
    }
}