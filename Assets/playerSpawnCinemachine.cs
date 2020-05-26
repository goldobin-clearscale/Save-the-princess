using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerSpawnCinemachine : MonoBehaviour
{
    private bool SearchingForThePlayer = false;
    private Transform player;
    private CinemachineVirtualCamera Vcam;
    // Start is called before the first frame update
    void Start()
    {
        Vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null){
            if(!SearchingForThePlayer){
                SearchingForThePlayer = true;
                StartCoroutine (FindingThePlayer());
            }
            return;
        }
        Vcam.Follow = player;
    }
    IEnumerator FindingThePlayer(){
        GameObject Result =  GameObject.FindGameObjectWithTag("Player");
        if(Result == null){
            yield return new WaitForSeconds(0.5f);
            StartCoroutine (FindingThePlayer());
        }
        else {
            player = Result.transform;
            SearchingForThePlayer = false;
            FixedUpdate ();
            yield return null;
        }
    }
}
