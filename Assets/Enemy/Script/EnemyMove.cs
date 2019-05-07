using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject Player;             //プレイヤーオブジェクト(命令ポインター)
    Vector3 PlayerDes;                              //Player座標保存変数
    private float PlayerDistance;                   //プレイヤーとの距離保存変数
    private float Speed = 0.2f;                     //移動スピード
    public bool IsAttack;
    public int HP;
    private EnemyStatus enemystatus;
    // ------------------------------------------------------
    NavMeshAgent agent;                             //徘徊用
    [SerializeField] private int destPoint = 0;     // 巡回地点のオブジェクト数（初期値=0）
    [SerializeField] private Transform[] points;    //巡回する地点のオブジェクト
    

    
    void Start()
    {
        Player = GameObject.Find("Player");
        enemystatus = GetComponent<EnemyStatus>();
        IsAttack = false;
        HP = 10;

        //経路探索（巡回）
        agent = GetComponent<NavMeshAgent>();           //経路のアタッチ
        agent.autoBraking = false;                      //減速回避
        GotoNextPoint();                                //初期の巡回ポイントを確保
    }



    void Update()
    {
        PlayerDes = Player.transform.position;
        PlayerDistance = Vector3.Distance(transform.position, PlayerDes);
        if(PlayerDistance>=5.0f)
        { 
            if (IsAttack==true)
            {
                //プレイヤー座標の方に少しずつ向きが変わる
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerDes - transform.position), 0.1f);

                //プレイヤーの居場所に向かって進む
                //transform.position += transform.forward * Speed;
                agent.SetDestination(PlayerDes);
            }
            else
            {
                // 巡回ポイントの通貨を確認
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    // 次ポイント取得
                    GotoNextPoint();
            }
        }
        enemystatus.SetHp(HP);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bug")
        {
            HP -= 1;
            Debug.Log("Hit Bug");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            IsAttack = true;
        }
    }


    public void Dead()
    {
        Destroy(this.gameObject);
    }

    // 次の巡回地点を設定する処理
    private void GotoNextPoint()
    {
        // 巡回地点が設定されていなければ
        if (points.Length == 0)
            return;

        // 現在選択されている配列の座標を巡回地点の座標に代入
        agent.destination = points[destPoint].position;
        // 配列の中から次の巡回地点を選択（必要に応じて繰り返し）
        destPoint = (destPoint + 1) % points.Length;
    }
}
