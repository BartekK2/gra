using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseInstantinate : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform bullet;
    private bool canShoot = true;
    void Start()
    {

    }

    IEnumerator Strzelanie()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            Transform pocisk;
            pocisk = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 2, transform.rotation);
            Rigidbody rigidbody;
            Transform sphere = pocisk.Find("Sphere");
            rigidbody = sphere.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * (Input.GetKey(KeyCode.LeftControl) ? 2000 : 500));
            sphere.transform.localScale = Input.GetKey(KeyCode.LeftControl) ? new Vector3(0.4f, 0.4f, 0.4f) : new Vector3(1f, 1f, 1f);
            Color kolor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            sphere.GetComponent<Renderer>().material.color = kolor;
            canShoot = false;
            StartCoroutine(Strzelanie());
        }
    }
}
