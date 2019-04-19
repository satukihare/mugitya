using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercamera : MonoBehaviour {
    
    

    [SerializeField] private float distance = 15.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転
    [SerializeField] private Transform Player;          // 注視対象プレイヤー
                                                        //unityのメイン画面→Main Camera→Inspector→
                                                        //このスクリプト→Playerの欄でオブジェクト指定する
    public PlayerScript playerScript;                   //プレイヤースクリプト取得

    private float angleH;
    public float rotSpeed = 180f;

    void Start()
    {
        // 回転の初期化
        vRotation = Quaternion.Euler(15, 0, 0);         // 垂直回転(X軸を軸とする回転)は、30度見下ろす回転
        hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転
        playerScript = Player.GetComponent<PlayerScript>();
        // 位置の初期化
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = Player.position - transform.rotation * Vector3.forward * distance;
    }

    void LateUpdate()
    {
        // カメラの位置(transform.position)の更新
        transform.position = Player.position + new Vector3(0, 2, 0) - transform.rotation * Vector3.forward * distance;

        if (playerScript.Is_OnR1 || Input.GetKey(KeyCode.Q))
        {
            angleH += 1 * rotSpeed * Time.deltaTime;
        }
        if (playerScript.Is_OnL1 || Input.GetKey(KeyCode.E))
        {
            angleH -= 1 * rotSpeed * Time.deltaTime;
        }
        
        Vector3 rotDir = Quaternion.Euler(15, angleH, 0f) * Vector3.back;
        transform.position = Player.position + distance * rotDir;

        transform.LookAt(Player.position);
    }
}
