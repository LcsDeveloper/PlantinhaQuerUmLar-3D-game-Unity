using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class falas : MonoBehaviour
{
    public GameObject fala;
    public Text frase;
    public string oqDizer;

    void Start()
    {
        
    }

    IEnumerator aparecer(){
        fala.SetActive(true);
        frase.text = oqDizer;
        yield return new WaitForSeconds(3);
        fala.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colli){
        if(colli.tag == "Player"){
            StartCoroutine("aparecer");
        }
    }
    
}
