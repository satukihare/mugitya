using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoOrderPosition : MonoBehaviour
{

    [SerializeField] GameObject OrderPointer;      //目指すオブジェクト(命令ポインター)
    [SerializeField] GameObject Player;             //プレイヤーオブジェクト(命令ポインター)
    Vector3 Destination;                            //OrderPointer座標保存変数
    Vector3 PlayerDes;                              //Player座標保存変数
    private float Speed = 0.1f;                     //移動スピード
    bool IsOrder = false;                           //命令されたか
    bool IsFollowPlayer = false;                    //自由かどうか？
    private float Distance;                         //ポインタとの距離保存変数
    private float PlayerDistance;                   //プレイヤーとの距離保存変数
    [SerializeField] private float AttractSize = 7;     // 香りに反応する距離

    public move playerScript;                   //プレイヤースクリプト取得

    Rigidbody m_Rigidbody;

    // Use this for initialization
    void Start()
    {
        //Rigidbodyのpositionとrotationを固定、解除する用
        Player = GameObject.Find("Player");
        OrderPointer = GameObject.Find("Pointer");
        playerScript = Player.GetComponent<move>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerDes = Player.transform.position;
        PlayerDistance = Vector3.Distance(transform.position, PlayerDes);

        if (IsFollowPlayer == false)
        {
            //香りが届ける範囲内にいるとプレイヤーについていくようになる。
            if (PlayerDistance <= AttractSize)
            {
                this.IsFollowPlayer = true;
            }
        }
        if (IsFollowPlayer == true)
        {
            //命令されてない
            if (this.IsOrder == false)
            {
                //プレイヤーとの間3.0fの距離を保つため
                if (PlayerDistance > 3.0f)
                {
                    //プレイヤー座標の方に少しずつ向きが変わる
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerDes - transform.position), 0.1f);

                    //プレイヤーの居場所に向かって進む
                    transform.position += transform.forward * Speed;
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }
                if (PlayerDistance <= 3.0f)
                {
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            //命令されたら
            if (Input.GetKeyDown(KeyCode.Space) ||  playerScript.Is_OnR2)
            {
                this.IsOrder = true;
                this.IsFollowPlayer = false;
                this.Destination = OrderPointer.transform.position;
            }
        }
        if (IsOrder == true)
        {
            //命令されたpositionの方に少しずつ向きが変わる
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Destination - transform.position), 0.1f);

            //命令されたpositionに向かって進む
            transform.position += transform.forward * Speed;

            //命令されたpositionについたら移動を中止
            Distance = Vector3.Distance(transform.position, Destination);
            if (Distance < 1.0f)
            {
                this.IsOrder = false;
                this.IsFollowPlayer = true;
                //m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
