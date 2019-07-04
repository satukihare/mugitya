using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderSrc : MonoBehaviour
{
    NavMeshAgent agent;                             // 徘徊用
    //[SerializeField] private int destPoint = 0;   // 巡回地点のオブジェクト数（初期値=0）
    [SerializeField] private Transform point;       // 巡回する地点のオブジェクト
    [SerializeField] private float intervalSize;    // 指示と虫との間隔

    private HitSearchErea erea;                     // 捜索範囲
    private bool bEreaIn;
    private Vector3 frontVec;                       // 前情報

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
    }


    void Update()
    {
        //子の情報から前ベクトル修正
        //calcFrontVec();
        //前ベクトルから進方向を修正
        updateChildPos();

        //子からエリアにオブジェクトがあるか捜索
        bEreaIn = erea.getEreaEnable();

        //状態遷移
        if (bEreaIn)
        {//範囲内
            InErea();
        }
        else
        {

        }

        // 止まっている状態のカウンタ
        stopMoveCount();
        // 壁への対応処理
        turnStopWall();

        //前ベクトルの位置更新
        agent.destination = point.position;

    }



    public void InErea()
    {
        switch (erea.getTagName())
        {
            // 火を見つけた際
            case "wind":
                Debug.Log("WindFind!!");
                FindFlower();
                break;

            case "fire":
                Debug.Log("FireHit");
                FindFire();
                break;
            default:
                break;
        }
    }

    //花を見つけた時
    private void FindFlower()
    {
        Vector3 _vec = erea.getHitPos();
        Vector3 _tecVec;
        _vec = _vec - this.transform.position;
        _tecVec.x = -_vec.x; _tecVec.y = 0; _tecVec.z = -_vec.z;
        //_tecVec.x =0; _tecVec.y = 0; _tecVec.z = -0.2f;

        //erea.transform.localPosition = _tecVec;
        transform.GetChild(1).gameObject.transform.position = this.transform.position + _tecVec.normalized * intervalSize * 50;
        //Debug.Log(_tecVec);

        calcFrontVec();
    }

    //ハチがエリアに侵入
    private void FindFire()
    {
        Vector3 _vec = erea.getHitPos();
        Vector3 _tecVec;
        _vec = _vec - this.transform.position;
        _tecVec.x = -_vec.x; _tecVec.y = 0; _tecVec.z = -_vec.z;
        //_tecVec.x =0; _tecVec.y = 0; _tecVec.z = -0.2f;

        //erea.transform.localPosition = _tecVec;
        transform.GetChild(1).gameObject.transform.position = this.transform.position + _tecVec.normalized * intervalSize * 50;
        //Debug.Log(_tecVec);

        calcFrontVec();
    }

    private void calcFrontVec()
    {
        frontVec = point.transform.position - this.transform.position;
    }

    private void updateChildPos()
    {
        //Debug.Log(frontVec.normalized);
        transform.GetChild(1).gameObject.transform.position = this.transform.position + frontVec.normalized * intervalSize * 50;
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
        transform.GetChild(1).gameObject.transform.position = this.transform.position + _tecVec.normalized * intervalSize * 50;

        calcFrontVec();
        //Debug.Log("反転(アリ)");
    }
}
