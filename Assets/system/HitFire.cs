using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFire : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(this.gameObject.transform.position.z<=GameObject.Find("Main Camera").transform.position.z+14)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="fire")
        {
            Destroy(this.gameObject);
        }
    }
}
