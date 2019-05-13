using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMove : MonoBehaviour
{
    public Transform target;
    public Vector3 TargetPos;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5.0f;
        agent.angularSpeed = 360.0f;
        agent.acceleration = 5.0f;
        agent.stoppingDistance = 2.0f;
        
    }

    void Update()
    {
        //agent.SetDestination(TargetPos);
        agent.destination = TargetPos;
        Debug.Log(TargetPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Fire")
        {
            Destroy(this.gameObject);
            //agent.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Fire")
        {
            TargetPos = other.transform.position;
        }
    }
}
