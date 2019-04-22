using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] private Vector3 Velocity;                  // 移動方向
    [SerializeField] private float MoveSpeed = 0.01f;           // 移動速度
    [SerializeField] private float RotationSpeed = 0.2f;        // 回転速度
    public int Life = 5;                                        // ライフポイント
    public bool Is_OnL1;                                        // ON/OFF判定
    public bool Is_OnL2;                                        // ON/OFF判定
    public bool Is_OnR1;                                        // ON/OFF判定
    public bool Is_OnR2;                                        // ON/OFF判定
    public float LeftStickX;                                    // 左スティックX値
    public float LeftStickY;                                    // 左スティックY値
    public float RightStickX;                                   // 右スティックX値
    public float RightStickY;                                   // 右スティックY値
    Rigidbody rb;
    public Vector3 cameraForward;
    public Vector3 moveForward;



    // Use this for initialization
    void Start () {
        Life = 5;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PadInput();

        KeyBoardInput();

        
    }

    private void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
 
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        moveForward = cameraForward * LeftStickY + Camera.main.transform.right * LeftStickX;
 
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * MoveSpeed + new Vector3(0, rb.velocity.y, 0);
 
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(-moveForward);
        }

    }


    public int SetLife()
    {
        return Life;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Life--;
        }
    }

    void PadInput()
    {
        //ゲームパッド移動
        //左スティックの値を取得
        LeftStickX = Input.GetAxis("Horizontal");
        LeftStickY = Input.GetAxis("Vertical") * -1.0f;
        RightStickX = Input.GetAxis("RightHorizontal");
        RightStickY = Input.GetAxis("RightVertical") * -1.0f;
        float DirectionKeyX= Input.GetAxis("LeftRight");
        float DirectionKeyY= Input.GetAxis("UpDown");

        if (Input.GetButton("L1")){ Is_OnL1 = true; } if (Input.GetButtonUp("L1")) { Is_OnL1 = false; }
        if (Input.GetButton("L2")){ Is_OnL2 = true; } if (Input.GetButtonUp("L2")) { Is_OnL2 = false; }
        if (Input.GetButton("R1")){ Is_OnR1 = true; } if (Input.GetButtonUp("R1")) { Is_OnR1 = false; }
        if (Input.GetButton("R2")){ Is_OnR2 = true; } if (Input.GetButtonUp("R2")) { Is_OnR2 = false; }
        if (Input.GetButton("Cross")){}
        if (Input.GetButton("Square")){}
        if (Input.GetButton("Triangle")){}
        if (Input.GetButton("Circle")){}
        if (DirectionKeyX == -1) { Debug.Log("Left"); }
        if (DirectionKeyX == 1)  { Debug.Log("Right"); }
        if (DirectionKeyY == -1) { Debug.Log("Down");}
        if (DirectionKeyY == 1)  { Debug.Log("Up"); }
    }

    void KeyBoardInput()
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
