using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderYarn : MonoBehaviour
{
    public bool SpiderYarnHit_;

    // Start is called before the first frame update
    void Start()
    {
        SpiderYarnHit_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpiderYarnHit_ = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpiderYarnHit_ = false;
        }

    }

    public bool SpiderYarnHIt()
    {
        return SpiderYarnHit_;
    }

}
