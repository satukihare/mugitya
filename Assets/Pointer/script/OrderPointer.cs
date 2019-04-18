using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPointer : MonoBehaviour
{
    [SerializeField] GameObject PlayerPointer;
    private Vector3 PlayerPos;              //プレイヤー座標
    private Vector3 Velocity;              // 移動方向
    private float MoveSpeed = 5.0f;        // 移動速度
    private float Distance;                // プレイヤー座標とポインタ座標の距離
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = PlayerPointer.transform.position;
        //両座標で距離を取得10を越えれば移動できない
        Distance = Vector3.Distance(transform.position, PlayerPos);
        Velocity = Vector3.zero;
        if (Distance<15.0f)
        {
            // ↑↓→←入力から、XZ平面(水平な地面)を移動する方向(Velocity)を得ます
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Velocity.z += 2;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Velocity.z -= 2;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Velocity.x -= 2;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Velocity.x += 2;
            }
        }

        // 速度ベクトルの長さを1秒でMoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime * 2;

        // いずれかの方向に移動している場合
        if (Velocity.magnitude > 0)
        {
            //プレイヤーの移動更新
            transform.position += Velocity;
            
        }

        //両者間距離が10超えたら一歩手前に戻す
        DistanceCheck();
    }

    void DistanceCheck()
    {
        PlayerPos = PlayerPointer.transform.position;
        //両座標で距離を取得10を越えれば移動できない
        Distance = Vector3.Distance(transform.position, PlayerPos);
        if (Distance > 15.0f)
        {
            //プレイヤーの移動更新
            transform.position -= Velocity;
        }
    }

}
