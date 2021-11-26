using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPicking : MonoBehaviour
{
    public GameObject itemx;
    // Start is called before the first frame update
    void Start()
    {
        pickUp(itemx);
    }

    public void pickUp(GameObject obiekt)
    {

        itemx.transform.parent = null;
        itemx.AddComponent<Rigidbody>();
        itemx = obiekt.gameObject;
        itemx.transform.parent = transform;
        itemx.transform.localPosition = new Vector3(-0.2f, -0.5f, 0.4f);
        Destroy(itemx.GetComponent<MeshCollider>());
        Destroy(itemx.GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
        itemx.transform.rotation = Quaternion.LookRotation(transform.forward);
    }
}
