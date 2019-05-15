using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{

    float Movespeed;
    Vector3 TargetPos;
    // Start is called before the first frame update
    void Start()
    {
        Movespeed = 0.02f;
        TargetPos = this.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        this.transform.position = new Vector3(this.transform.position.x + TargetPos.x * Movespeed,
                                              this.transform.position.y + TargetPos.y * Movespeed,
                                              this.transform.position.z + TargetPos.z * Movespeed);

        if (this.transform.position.z <= GameObject.Find("Main Camera").transform.position.z+10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="fire")
        {
            Debug.Log("Hit Fire");
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==("fire"))
        {
            Vector3 ToTarget = other.transform.position - this.transform.position;
            TargetPos = ToTarget.normalized;
            this.transform.forward = TargetPos;
        }
    }
}
