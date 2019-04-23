using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPointer : MonoBehaviour
{
    [SerializeField] GameObject PlayerPointer;
    private Vector3 PlayerPos;              //プレイヤー座標
    private Vector3 Velocity;               // 移動方向
    private float MoveSpeed = 10.0f;        // 移動速度
    private float Distance;                 // プレイヤー座標とポインタ座標の距離
    private move Playerscript;
    Rigidbody rb;                           //ポインターのRigibody
    public Vector3 PointercameraForward;    //カメラの向きに合わせてポインターを動かすために、カメラの向きの保存用
    public Vector3 PointermoveForward;      //カメラの向きに合わせてポインターを動かすために、カメラの向きの保存用
    float RightStickX;                      //RスティックX値
    float RightStickY;                      //RスティックY値
    bool IsPointerMoved;                    //ポインターを使っているか？

    // Use this for initialization
    void Start()
    {
        Playerscript = PlayerPointer.GetComponent<move>();
        rb = GetComponent<Rigidbody>();
        IsPointerMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = PlayerPointer.transform.position;
        //右スティックの値を取得
        RightStickX = Input.GetAxis("RightHorizontal");
        RightStickY = Input.GetAxis("RightVertical") * -1.0f;
        //Rスティックの値でポインター使っているかを判断
        //上下左右の値全部0ならfalse
        //上下左右の値全部0じゃない場合はtrue
        if (RightStickX == 0 && RightStickY == 0) { IsPointerMoved = false; } //gameObject.SetActive(false); }
        if (RightStickX != 0 || RightStickY != 0){IsPointerMoved = true; } //gameObject.SetActive(true); }
        //ポインターを表示するかを判断
        if (IsPointerMoved == false)
        {
            this.transform.position = new Vector3(PlayerPos.x, this.transform.position.y, PlayerPos.z);
        }
        if (IsPointerMoved == true)
        {
            
        }
    }

    private void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        PointercameraForward = Playerscript.cameraForward;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        PointermoveForward = PointercameraForward * RightStickY + Camera.main.transform.right * RightStickX;
        Debug.Log(PointermoveForward);
        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = PointermoveForward * MoveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (PointermoveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(-PointermoveForward);
        }
    }

}
