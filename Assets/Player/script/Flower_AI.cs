using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flower_AI : MonoBehaviour
{

    NavMeshAgent agent;                             // 徘徊用
    //[SerializeField] private int destPoint = 0;   // 巡回地点のオブジェクト数（初期値=0）
    [SerializeField] private Transform point;       // 巡回する地点のオブジェクト
    [SerializeField] private float intervalSize;    // 指示と虫との間隔

    private HitSearchErea erea;                     // 捜索範囲
    private bool bEreaIn;
    private Vector3 frontVec;                       // 前情報
    private float moveSpeed;


    void Start()
    {
        //　経路探索
        agent = GetComponent<NavMeshAgent>();           //経路のアタッチ
        agent.autoBraking = false;                      //減速回避
        //GotoNextPoint();                              //初期の巡回ポイントを確保
        agent.destination = point.position;
        erea = GetComponent<HitSearchErea>();           //子のゲームobjectを取得
        calcFrontVec();
        moveSpeed = agent.speed;                        //スピード確保
    }


    void Update()
    {
        //子の情報から前ベクトル修正
        //calcFrontVec();
        //前ベクトルから進方向を修正
        updateChildPos();

        //子からエリアにオブジェクトがあるか捜索
        //bEreaIn = erea.getInErea();

        //状態遷移
        //if (erea.getEreaEnable)
        //{//範囲内
        //    InErea();
        //}
        //else
        //{
        //    agent.speed = moveSpeed;
        //}
        if(erea.getEreaEnable())
        {
            InErea();
        }
        else if(!erea.getInErea())
        {
            agent.speed = moveSpeed;
        }
        agent.destination = point.position;
    }


    //虫類に触れたらとまる
    public void InErea()
    {
        agent.speed = 0;
    }

    private void calcFrontVec()
    {
        frontVec = point.transform.position - this.transform.position;
    }

    private void updateChildPos()
    {
        transform.GetChild(1).gameObject.transform.position = this.transform.position + frontVec.normalized * intervalSize * 50;
    }
}
