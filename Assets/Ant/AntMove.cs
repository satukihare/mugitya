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
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + this.transform.forward.x * Movespeed,
                                              this.transform.position.y + this.transform.forward.y * Movespeed,
                                              this.transform.position.z + this.transform.forward.z * Movespeed);

        if (this.transform.position.z <= GameObject.Find("Main Camera").transform.position.z+10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==("Fire"))
        {
            TargetPos = other.transform.position;

        }
    }
}
