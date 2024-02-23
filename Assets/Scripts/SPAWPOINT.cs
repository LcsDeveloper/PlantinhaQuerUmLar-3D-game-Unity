using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWPOINT : MonoBehaviour
{
    public Transform point;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colli){
        if(colli.tag == "Player"){
            player.transform.position = point.position;
        }
    }
}
