using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CUTSCENE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CUT");
    }

    IEnumerator CUT(){
        yield return new WaitForSeconds(40);
        SceneManager.LoadScene("SampleScene");
    }
    void Update()
    {
        
    }
}
