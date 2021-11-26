using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemx : MonoBehaviour
{
    public GameObject model;
    public GameObject player;
    private GameObject go;
    void Awake()
    {
        go = Instantiate(model, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(0f, 0f, 0f);
        gameObject.AddComponent<Rigidbody>();
        go.AddComponent<MeshCollider>();
        go.GetComponent<MeshCollider>().convex = true;
        if (model.GetComponent<MeshFilter>())
        {
            go.GetComponent<MeshCollider>().sharedMesh = model.GetComponent<MeshFilter>().sharedMesh;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            // gameObject.AddComponent<Rigidbody>();
            player.gameObject.GetComponent<itemPicking>().pickUp(GameObject.Find("Empty"));
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "XD" && Input.GetKey(KeyCode.P))
        {
            collision.gameObject.GetComponent<itemPicking>().pickUp(transform.gameObject);
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
