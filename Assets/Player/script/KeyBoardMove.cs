﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMove : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float applySpeed = 0.2f;       // 回転の適用速度
    [SerializeField] private cameramove refCamera;  // カメラの水平回転を参照する用
    Rigidbody rb;
    bool YarnHit;

    private void Start()
    {
        refCamera = GameObject.Find("Main Camera").GetComponent<cameramove>();
        YarnHit = false;
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    void Update()
    {
        //キーボード入力
        KeyBoardInput();
        //移動処理
        Transform();
        
    }

    void KeyBoardInput()
    {
        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;
    }

    void Transform()
    {

        if (YarnHit)
        { 
            // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
            velocity = velocity.normalized * moveSpeed * Time.deltaTime/2;
        }
        else
        {
            // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
            velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        }

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、
            // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera.hRotation * velocity), applySpeed);

            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
            transform.position += refCamera.hRotation * velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Yarn")
        {
            YarnHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Yarn")
        {
            YarnHit = false;
        }
    }
}
