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
        agent.destination = TargetPos;
        Debug.Log(TargetPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="fire")
        {
            Destroy(this.gameObject);
            //agent.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="fire")
        {
            TargetPos = other.transform.position;
        }
    }
}
