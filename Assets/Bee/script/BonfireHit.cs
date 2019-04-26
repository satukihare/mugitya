using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            //仮で当たると消す
            transform.gameObject.SetActive(false);
        }

    }
}
