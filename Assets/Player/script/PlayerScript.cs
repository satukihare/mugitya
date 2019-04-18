using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] private Vector3 Velocity;              // 移動方向
    [SerializeField] private float MoveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float RotationSpeed = 0.2f;    // 回転速度
    public int Life = 5;                   // ライフポイント
    // Use this for initialization
    void Start () {
        Life = 5;
	}

    // Update is called once per frame
    void Update()
    {
        // WASD入力から、XZ平面(水平な地面)を移動する方向(Velocity)を得ます
        Velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Velocity.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Velocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Velocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Velocity.x += 1;
        }
        // 速度ベクトルの長さを1秒でMoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (Velocity.magnitude > 0)
        {
            //プレイヤーの移動更新
            transform.position += Velocity;
            //プレイヤーの回転更新
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Velocity), RotationSpeed);
        }
    }


    public int SetLife()
    {
        return Life;
    }
}
