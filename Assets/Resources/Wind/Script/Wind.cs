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
        WindSpeed = 20.0f;
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

        //// 相対速度計算
        var relativeVelocity = velocity - other.GetComponent<Rigidbody>().velocity;

        //// 空気抵抗を与える
        other.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);

        if (other.tag=="ant" && this.gameObject.name!="WindItem")
        {
            //Debug.Log(other.transform.position);
            // 相対速度計算
            relativeVelocity = velocity - other.GetComponent<Rigidbody>().velocity;

            // 空気抵抗を与える
            other.GetComponent<Rigidbody>().AddForce((coefficient * relativeVelocity)/5);

        }
        

    }
}
