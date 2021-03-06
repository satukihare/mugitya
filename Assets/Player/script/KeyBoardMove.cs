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
    float RotY;
    int Speed = 3;
    bool SpeedMagnification;

    private void Start()
    {
        refCamera = GameObject.Find("Main Camera").GetComponent<cameramove>();
        YarnHit = false;
        rb = GetComponent<Rigidbody>();
        RotY = 0;
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        SpeedMagnification = false;
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
        if (Input.GetKey(KeyCode.Q))
        { 
            RotY -= 2;
        }
        if (Input.GetKey(KeyCode.E))
        {
            RotY += 2;
        }
        //K長押しで加速
        //K放すと戻る
        if(Input.GetKey(KeyCode.K))
        {
            Speed = 5;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            Speed = 3;
        }

        //ゲーム進行速度変更
        if (Input.GetKeyDown(KeyCode.J))
        {
            switch(Time.timeScale)
            {
                case 1:
                    Time.timeScale = 2f;
                    Debug.Log(Time.timeScale);
                    break;
                case 2:
                    Time.timeScale = 1f;
                    Debug.Log(Time.timeScale);
                    break;
            }
        }


    }

    void Transform()
    {
        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime * Speed;

        //向き調整
        this.transform.rotation = Quaternion.Euler(0, RotY, 0);

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
            transform.position += refCamera.hRotation * velocity;
        }
        if (this.transform.position.z <= GameObject.Find("Main Camera").transform.position.z + 13)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, GameObject.Find("Main Camera").transform.position.z + 13);
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
