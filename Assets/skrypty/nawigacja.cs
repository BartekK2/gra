using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nawigacja : MonoBehaviour
{
    [SerializeField] private Transform movePosition;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = movePosition.position;
    }
}
