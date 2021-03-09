using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //FadeFunction();
            StartCoroutine(FadeCoroutine());
        }
    }

    public void FadeFunction()
    {
        Debug.Log("FadeFunction should be running");
        for(float ft = 1f;ft>=0; ft -= 0.01f)
        {
            Color c = this.gameObject.GetComponent<MeshRenderer>().material.color;            
            c.a = ft;
            this.gameObject.GetComponent<MeshRenderer>().material.color = c;
        }

    }

    public IEnumerator FadeCoroutine()
    {
        
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            Color c = this.gameObject.GetComponent<MeshRenderer>().material.color;
            c.a = ft;
            this.gameObject.GetComponent<MeshRenderer>().material.color = c;
            Debug.Log("FadeFunction should be running");
            yield return new WaitForSeconds(2f);
        }
    }



}
