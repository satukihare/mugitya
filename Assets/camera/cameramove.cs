﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1.0f;    // 回転速度
    [SerializeField] private Transform player;          // 注視対象プレイヤー
    [SerializeField] private Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;       // カメラの水平回転
    private float distance = 55.0f;                     // 注視対象プレイヤーからカメラを離す距離
    //private GameObject Player;
    private GamePad gamepad;
    public AudioSource audioSource;
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;
    public bool Is_ResultOn;
    float MoveSpeed = 0.03f;
    void Start()
    {
        FadeManager.FadeIn();
        // 回転の初期化
        vRotation = Quaternion.Euler(30, 0, 0);         // 垂直回転(X軸を軸とする回転)は、30度見下ろす回転
        hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転
        gamepad = GameObject.Find("Pointer").GetComponent<GamePad>();
        // 位置の初期化
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
        //Player = GameObject.Find("Pointer");
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
        Is_ResultOn = false;
    }

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            MoveSpeed = 0.05f;
        }
        if (Time.timeScale == 2f)
        {
            MoveSpeed = 0.2f;
        }
        Debug.Log(MoveSpeed);

        transform.rotation = hRotation * vRotation;

        // カメラの位置(transform.position)の更新
        // player位置から距離distanceだけ手前に引いた位置を設定します(位置補正版)
        //transform.position = player.position + new Vector3(0, 5, 0) - transform.rotation * Vector3.forward * distance;
        if(Time.timeScale !=0f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z + (MoveSpeed));
        }
        


        if (this.transform.position.z >= GameObject.Find("Spaceship").transform.position.z - 30 && Is_ResultOn == false)
        {
            Is_ResultOn = true;
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            GameObject.Find("gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
    }
}

    //void LateUpdate()
    //{
    //    if (Mathf.Approximately(Time.timeScale, 0f))
    //    {
    //        return;
    //    }
    //
    //    transform.rotation = hRotation * vRotation;
    //
    //    // カメラの位置(transform.position)の更新
    //    // player位置から距離distanceだけ手前に引いた位置を設定します(位置補正版)
    //    //transform.position = player.position + new Vector3(0, 5, 0) - transform.rotation * Vector3.forward * distance;
    //    transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z + (MoveSpeed));
    //
    //
    //    if(this.transform.position.z>=GameObject.Find("Spaceship").transform.position.z-30 && Is_ResultOn == false)
    //    {
    //        Is_ResultOn = true;
    //        pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
    //        GameObject.Find("gameUI").SetActive(false);
    //        Time.timeScale = 0f;
    //    }
    //}
//}
