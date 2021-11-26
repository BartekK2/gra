using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingTowards : MonoBehaviour
{
    public GameObject cel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.up, cel.transform.position - transform.position);
        desiredRotation = Quaternion.Euler(0, desiredRotation.eulerAngles.y - 90, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 100 * Time.deltaTime);
    }
}