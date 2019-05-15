using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSearchErea : MonoBehaviour
{
    private bool b_ereaIn;

    void Start()
    {
        b_ereaIn = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 情報を親へ渡すためのGetter
    public bool getEreaEnable()
    {
        return b_ereaIn;
    }
    
    //　エリアに侵入
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("end");
            b_ereaIn = true;
        }
    }
    //エリアから脱出
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("end");
            b_ereaIn = false;
        }
    }
}
