using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    Vector2 whereToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        whereToSpawn = new Vector2 (transform.position.x, transform.position.y);
        Instantiate (player, whereToSpawn, Quaternion.identity);
    }
}
