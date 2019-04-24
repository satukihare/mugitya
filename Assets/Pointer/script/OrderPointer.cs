using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPointer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] private Vector3 Velocity;              // 移動方向
    [SerializeField] private float MoveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float applySpeed = 0.2f;       // 回転の適用速度
    [SerializeField] private cameramove refCamera;  // カメラの水平回転を参照する用
    Rigidbody rb;                           //ポインターのRigibody
    float RightStickX;                      //RスティックX値
    float RightStickY;                      //RスティックY値
    bool IsPointerMoved;                    //ポインターを使っているか？
    float PlayerDistance;                   //プレイヤーとの距離保存変数
    private Vector3 OldPlayerPos;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        refCamera = GameObject.Find("Main Camera").GetComponent<cameramove>();
        IsPointerMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = Vector3.zero;
        IsPointerMoved = false;
        //GamePad入力
        GamepadInput();
        //キーボード入力
        KeyboardInput();
        //移動処理
        Translate();
    }

    void GamepadInput()
    {
        //右スティックの値を取得
        RightStickX = Input.GetAxis("BoxRightHorizontal");
        RightStickY = Input.GetAxis("BoxRightVertical") * -1.0f;
        
        if (RightStickX > 0)
           Velocity.x += RightStickX;
        if (RightStickX < 0)
           Velocity.x += RightStickX;
        if (RightStickY > 0)
           Velocity.z += RightStickY;
        if (RightStickY < 0)
           Velocity.z += RightStickY;
    }

    void KeyboardInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Velocity.z += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            Velocity.x -= 1;
        if (Input.GetKey(KeyCode.DownArrow))
            Velocity.z -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            Velocity.x += 1;
    }

    void Translate()
    {
        PlayerDistance = Vector3.Distance(transform.position, Player.transform.position);

        //if (OldPlayerPos!=Player.transform.position || Input.GetButton("R2") ||Input.GetKey(KeyCode.Space))
        //{
        //    IsPointerMoved = true;
        //}
        if (PlayerDistance >= 20.0f || OldPlayerPos != Player.transform.position)
        {
            transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z);
        }
        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;
        // いずれかの方向に移動している場合
        if (Velocity.magnitude > 0)
        {
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、
            // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera.hRotation * Velocity), applySpeed);

            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足し込みます
            transform.position += refCamera.hRotation * Velocity;
        }

        OldPlayerPos = Player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
