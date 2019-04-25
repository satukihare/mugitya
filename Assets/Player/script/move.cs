using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private Vector3 Velocity;              // 移動方向
    [SerializeField] private float MoveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float ApplySpeed = 0.2f;       // 回転の適用速度
    [SerializeField] private cameramove RefCamera;  // カメラの水平回転を参照する用
    public float LeftStickX;                                    // 左スティックX値
    public float LeftStickY;                                    // 左スティックY値
    Rigidbody rb;

    public Vector3 cameraForward;
    public Vector3 moveForward;
    private GamePad gamepad;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RefCamera = GameObject.Find("Main Camera").GetComponent<cameramove>();
        gamepad = GetComponent<GamePad>();
    }

    void Update()
    {
        GamePadInput();

        Transform();

    }

    void GamePadInput()
    {
        LeftStickX = gamepad.GetLeftStickX();
        LeftStickY = gamepad.GetLeftStickY();
        Velocity = Vector3.zero;
        if (LeftStickX > 0)
        {
            Velocity.x += LeftStickX;
        }
        if (LeftStickX < 0)
        {
            Velocity.x += LeftStickX;
        }
        if (LeftStickY > 0)
        {
            Velocity.z += LeftStickY;
        }
        if (LeftStickY < 0)
        {
            Velocity.z += LeftStickY;
        }
        //入力検証
        if (gamepad.GetCross()) { Debug.Log("Cross is be Pushed"); }
        if (gamepad.GetCircle()) { Debug.Log("Circle is be Pushed"); }
        if (gamepad.GetSquare()) { Debug.Log("Square is be Pushed"); }
        if (gamepad.GetTriangle()) { Debug.Log("Triangle is be Pushed"); }
        if (gamepad.GetDirectionKeyX()==-1) { Debug.Log("Left"); }
        if (gamepad.GetDirectionKeyX()== 1) { Debug.Log("Right"); }
        if (gamepad.GetDirectionKeyY()==-1) { Debug.Log("Down"); }
        if (gamepad.GetDirectionKeyY()== 1) { Debug.Log("Up"); }
    }

    void Transform()
    {
        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (Velocity.magnitude > 0)
        {
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、
            // カメラの水平回転(RefCamera.hRotation)で回した移動の反対方向(-Velocity)に回す回転に段々近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(RefCamera.hRotation * Velocity), ApplySpeed);

            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(RefCamera.hRotation)で回した移動方向(Velocity)を足し込みます
            transform.position += RefCamera.hRotation * Velocity;
        }
    }
}
