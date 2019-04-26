using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    


    public float coefficient;   // 空気抵抗係数
    public Vector3 velocity;    // 風速
    public GameObject pointer;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() == null)
        {
            return;
        }


        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bug")
        {
            // 相対速度計算
            var relativeVelocity = velocity - other.GetComponent<Rigidbody>().velocity;

            // 空気抵抗を与える
            other.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);

            pointer.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);
        }
    }
    

}
