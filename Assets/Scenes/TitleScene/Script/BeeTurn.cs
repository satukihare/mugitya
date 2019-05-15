using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTurn : MonoBehaviour
{
    // 回転の中心になるオブジェクト
    public Transform target;
    // 回転速度
    public float speed = 20.0f;

    void Update()
    {
        Vector3 axis = transform.TransformDirection(Vector3.up);
        transform.RotateAround(target.position, axis, -speed * Time.deltaTime);
    }
}
