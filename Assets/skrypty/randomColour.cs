using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Color kolor = new Color(
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f), 
                Random.Range(0f, 1f)
            );
            GetComponent<Renderer>().material.color = kolor;
        }
    }
}
