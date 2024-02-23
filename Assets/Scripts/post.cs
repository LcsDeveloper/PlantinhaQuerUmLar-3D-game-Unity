using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class post : MonoBehaviour
{
    public GameObject post1;
    public GameObject post2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colli){
        if(colli.tag == "Player"){
            post1.SetActive(false);
            post2.SetActive(true);
        }
    }
}
