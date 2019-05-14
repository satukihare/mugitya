using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float coefficient;                               // 空気抵抗係数
    public Vector3 velocity;                                // 風速
    public float WindSpeed; 
    float RotY;

    void Start()
    {
        RotY = 0;
        coefficient = 10.0f;
        WindSpeed = 10.0f;
    }

    void Update()
    {
        
        velocity = transform.forward * WindSpeed ;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() == null)
        {
            return;
        }
        if(other.gameObject.tag=="Bug" && this.gameObject.name!="WindItem")
        {
            //other.transform.forward = this.transform.forward;

            // 相対速度計算
            var relativeVelocity = velocity - other.GetComponent<Rigidbody>().velocity;

            // 空気抵抗を与える
            other.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);
        }
    }
}
