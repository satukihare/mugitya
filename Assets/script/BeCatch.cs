using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeCatch : MonoBehaviour
{
    GameObject Catching;
    bool Becatch;
    // Start is called before the first frame update
    void Start()
    {
        Becatch = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Becatch==true)
        {
            transform.position = new Vector3(Catching.transform.position.x, Catching.transform.position.y + 1, Catching.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(Becatch==false)
        {
            if (other.gameObject.tag == "Bug")
            {
                Catching = other.gameObject;
                Debug.Log("Catching is" + Catching.gameObject.name);
                Becatch = true;
            }
        }
        
    }
}
