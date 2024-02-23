using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{

    public Transform player;
    public float X, Y, x, y;
    public float sensi;

    public float min, max;
    public float TRAVAmin, TRAVAmax;

    bool start;
    
    void Start()
    {
        StartCoroutine("inicio");
    }

    IEnumerator inicio(){
        start = false;
        yield return new WaitForSeconds(51);
        start= true;
    }
    
    void FixedUpdate()
    {
        transform.position = player.position;

        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");

        x += X * sensi * Time.deltaTime;
        y -= Y * sensi * Time.deltaTime;

        y = Mathf.Clamp(y, min, max);

        if(!start){
            x = Mathf.Clamp(x, TRAVAmin, TRAVAmax);
        }

        transform.eulerAngles = new Vector3(y, x, transform.rotation.z);

    }
}
