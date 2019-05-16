using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private Vector3 Velocity;              // 移動方向
    [SerializeField] private float MoveSpeed = 10.0f;        // 移動速度
    [SerializeField] private float ApplySpeed = 0.2f;       // 回転の適用速度
    [SerializeField] private cameramove RefCamera;  // カメラの水平回転を参照する用
    public float LeftStickX;                                    // 左スティックX値
    public float LeftStickY;                                    // 左スティックY値
    public float RightStickX;                                   // 右スティックY値
    float RotY;
    Rigidbody rb;
    
    public Vector3 cameraForward;
    public Vector3 moveForward;
    private GamePad gamepad;
    public int Life;
    bool YarnHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RefCamera = GameObject.Find("Main Camera").GetComponent<cameramove>();
        gamepad = GetComponent<GamePad>();
        Life = 5;
        YarnHit = false;
        RotY = 0;
        //rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Update()
    {
        // 接続されているコントローラの名前を調べる
        var controllerNames = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければエラー
        //if (controllerNames[0] != "")
        //{
            GamePadInput();

            Transform();
        //}
    }

    void GamePadInput()
    {
        LeftStickX = gamepad.GetLeftStickX();
        LeftStickY = gamepad.GetLeftStickY();
        RightStickX = gamepad.GetRightStickX();
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
        RotY += RightStickX*2;
    }

    void Transform()
    {
        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime*3;

        //向き調整
        this.transform.rotation = Quaternion.Euler(0, RotY, 0);

        // いずれかの方向に移動している場合
        if (Velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(RefCamera.hRotation)で回した移動方向(Velocity)を足し込みます
            this.transform.position += RefCamera.hRotation * Velocity;
            
        }
        if(this.transform.position.z<=GameObject.Find("Main Camera").transform.position.z+13)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, GameObject.Find("Main Camera").transform.position.z + 13); 
        }
    }

    //collider当たった時
    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Yarn")
        {
            YarnHit = false;
        }
    }
}
