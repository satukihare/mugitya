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
    float DirectionKeyX;
    float DirectionKeyY;
    Rigidbody rb;
    public bool Is_OnL1;                                        // ON/OFF判定
    public bool Is_OnL2;                                        // ON/OFF判定
    public bool Is_OnR1;                                        // ON/OFF判定
    public bool Is_OnR2;                                        // ON/OFF判定

    public Vector3 cameraForward;
    public Vector3 moveForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RefCamera = GameObject.Find("Main Camera").GetComponent<cameramove>();
    }

    void Update()
    {
        GamePadInput();

        Transform();

    }

    void GamePadInput()
    {
        LeftStickX = Input.GetAxisRaw("Horizontal");
        LeftStickY = Input.GetAxisRaw("Vertical") * -1.0f;
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
        if (Input.GetButton("L1")) { Is_OnL1 = true; }
        if (Input.GetButtonUp("L1")) { Is_OnL1 = false; }
        if (Input.GetButton("L2")) { Is_OnL2 = true; }
        if (Input.GetButtonUp("L2")) { Is_OnL2 = false; }
        if (Input.GetButton("R1")) { Is_OnR1 = true; }
        if (Input.GetButtonUp("R1")) { Is_OnR1 = false; }
        if (Input.GetButton("R2")) { Is_OnR2 = true; }
        if (Input.GetButtonUp("R2")) { Is_OnR2 = false; }
        if (Input.GetButton("Cross")) { }
        if (Input.GetButton("Square")) { }
        if (Input.GetButton("Triangle")) { }
        if (Input.GetButton("Circle")) { }
        DirectionKeyX = Input.GetAxis("LeftRight");
        DirectionKeyY = Input.GetAxis("UpDown");
        if (DirectionKeyX == -1) { Debug.Log("Left"); }
        if (DirectionKeyX == 1) { Debug.Log("Right"); }
        if (DirectionKeyY == -1) { Debug.Log("Down"); }
        if (DirectionKeyY == 1) { Debug.Log("Up"); }
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

    bool GetL1()
    {
        return Is_OnL1;
    }
    bool GetL2()
    {
        return Is_OnL2;
    }
    bool GetR1()
    {
        return Is_OnR1;
    }
    bool GetR2()
    {
        return Is_OnR2;
    }
    float GetLeftStickX()
    {
        return LeftStickX;
    }
    float GetLeftStickY()
    {
        return LeftStickY;
    }
}
