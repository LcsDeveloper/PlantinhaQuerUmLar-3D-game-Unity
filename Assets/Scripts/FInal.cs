using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInal : MonoBehaviour
{
    public GameObject fadeFINAL;

    void Start()
    {
        
    }

    IEnumerator final(){
        yield return new WaitForSeconds(5);
        fadeFINAL.SetActive(true);
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("MENU");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colli){
        if(colli.tag == "Player"){
            StartCoroutine("final");
        }
    }
}
