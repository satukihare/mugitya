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

    private Vector3 beforePos = new Vector3(0, 0, 0);         // 前フレームの位置
    private int stopCount;                                  // 止まったフレームをカウント
    [SerializeField] private float intervalPos;             // 位置誤差
    [SerializeField] private int intervalFlame;             // 静止フレーム誤差 
    private float vecFront_Height = 0.15f;


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
        // 止まっている状態のカウンタ
        stopMoveCount();
        // 壁への対応処理
        turnStopWall();

        //前ベクトルの位置更新
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
        transform.GetChild(3).gameObject.transform.position = this.transform.position + frontVec.normalized * intervalSize * 50;
    }

    // 静止フレームカウント
    private void stopMoveCount()
    {
        Vector3 _nowpos = this.transform.position;
        // 位置更新をしているか
        if (_nowpos.x > beforePos.x - intervalPos &&
            _nowpos.x < beforePos.x + intervalPos &&
            _nowpos.z > beforePos.z - intervalPos &&
            _nowpos.z < beforePos.z + intervalPos)
        {
            //Debug.Log("壁際");
            stopCount++;
        }
        else
        {
            beforePos = _nowpos;
            stopCount = 0;
        }
    }

    // 壁際での反転処理（判断も）
    private void turnStopWall()
    {
        if (stopCount < intervalFlame)
        {
            //Debug.Log("反転できなかった！");
            return;
        }
        Vector3 _tecVec;
        _tecVec = this.transform.position - frontVec;
        _tecVec.y = vecFront_Height;
        transform.GetChild(3).gameObject.transform.position = this.transform.position + _tecVec.normalized * intervalSize * 50;

        calcFrontVec();
        //Debug.Log("反転(花)");
    }
}
