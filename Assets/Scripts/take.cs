using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take : MonoBehaviour
{
    
    public Transform point;
    public bool pegar, pegado;

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        peguei();
    }

    void peguei(){
        
        if(Input.GetButtonDown("Fire3") && pegado == true){
            pegado = false;
            transform.position = transform.position;
        }

        if(pegar){
            if(Input.GetButtonDown("Fire3")){
                pegado = true;
            }
        }

        if(pegado){
            transform.position = point.position;
        }

    }

    void OnCollisionEnter(Collision colli){
        if(colli.collider.tag == "Player"){
            pegar = true;
        }
    }

    void OnCollisionExit(Collision colli){
        if(colli.collider.tag == "Player"){
            pegar = false;
        }
    }
}
