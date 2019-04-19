using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject Player;             //プレイヤーオブジェクト(命令ポインター)
    Vector3 PlayerDes;                              //Player座標保存変数
    private float PlayerDistance;                   //プレイヤーとの距離保存変数
    private float Speed = 0.2f;                     //移動スピード
    public bool IsAttack;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        IsAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDes = Player.transform.position;
        PlayerDistance = Vector3.Distance(transform.position, PlayerDes);

        if (IsAttack==true)
        {
            //プレイヤー座標の方に少しずつ向きが変わる
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerDes - transform.position), 0.1f);

            //プレイヤーの居場所に向かって進む
            transform.position += transform.forward * Speed;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            IsAttack = true;
        }
    }
}
