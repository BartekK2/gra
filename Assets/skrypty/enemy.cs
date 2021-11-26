using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject cel;

    private Quaternion startRotation;


    void Start()
    {
        startRotation = transform.rotation;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            Destroy(collision.gameObject);
            transform.localScale = new Vector3((float)health / 100, (float)health / 100, (float)health / 100);
            health -= 10;
            if (health <= 0) { Destroy(this.gameObject); }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.up, cel.transform.position - transform.position);
        desiredRotation = Quaternion.Euler(startRotation.eulerAngles.x, desiredRotation.eulerAngles.y, startRotation.eulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 1000 * Time.deltaTime);
        transform.position += -transform.forward * 3 * Time.deltaTime;
    }
}
