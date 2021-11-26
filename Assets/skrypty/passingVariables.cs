using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passingVariables : MonoBehaviour
{

    public GameObject x;
    private obiekt y;

    void Awake()
    {
        y = x.GetComponent<obiekt>();
    }
    void Update()
    {
        // print(y.zmienna);
    }
}
