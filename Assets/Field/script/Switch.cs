using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        block = GameObject.Find("Block");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(block);
        }
    }
}
