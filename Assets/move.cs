using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float LeftStickX;                                    // 左スティックX値
    public float LeftStickY;                                    // 左スティックY値
    public float RightStickX;                                   // 右スティックX値
    public float RightStickY;                                   // 右スティックY値
    float DirectionKeyX;
    float DirectionKeyY;
    Rigidbody rb;

    float moveSpeed = 5.0f;
    public bool Is_OnL1;                                        // ON/OFF判定
    public bool Is_OnL2;                                        // ON/OFF判定
    public bool Is_OnR1;                                        // ON/OFF判定
    public bool Is_OnR2;                                        // ON/OFF判定

    public Vector3 cameraForward;
    public Vector3 moveForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        LeftStickX = Input.GetAxisRaw("Horizontal");
        LeftStickY = Input.GetAxisRaw("Vertical") * -1.0f;
        RightStickX = Input.GetAxisRaw("RightHorizontal");
        RightStickY = Input.GetAxisRaw("RightVertical") * -1.0f;
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

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        moveForward = cameraForward * LeftStickY + Camera.main.transform.right * LeftStickX;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
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
    float GetRightStickX()
    {
        return RightStickX;
    }
    float GetRightStickY()
    {
        return RightStickY;
    }
}
