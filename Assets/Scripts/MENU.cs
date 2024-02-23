using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    public GameObject TRANSI;

    void Start()
    {
        
    }

    IEnumerator passar(){   
        
        TRANSI.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("CUTSCENEINIT"); 

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Jump") > 0){
            StartCoroutine("passar");
        }
    }
}
