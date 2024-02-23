using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folhinhaSOL : MonoBehaviour
{
    public GameObject player;
    public GameObject folha;
    public Transform point;
    bool sol, chuva, isSPAW;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sol = player.GetComponent<mov>().sol;
        chuva = player.GetComponent<mov>().chuva;

        if(sol && isSPAW){
            isSPAW = false;
            Instantiate(folha, point.position, transform.rotation);
            GetComponent<MeshRenderer>().enabled = false;
        }

        if(chuva){
            GetComponent<MeshRenderer>().enabled = true;
            isSPAW = true;
        }
    }
}
