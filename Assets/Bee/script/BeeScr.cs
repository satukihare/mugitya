using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeScr : MonoBehaviour
{
    NavMeshAgent agent;                             // 徘徊用
    //[SerializeField] private int destPoint = 0;   // 巡回地点のオブジェクト数（初期値=0）
    [SerializeField] private Transform point;       // 巡回する地点のオブジェクト
    [SerializeField] private float intervalSize;    // 指示と虫との間隔

    private HitSearchErea erea;                     // 捜索範囲
    private bool bEreaIn;
    private Vector3 frontVec;                       // 前情報


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
        agent.destination = point.position;
    }



    public void InErea()
    {
        switch (erea.getTagName())
        {
            // 火を見つけた際
            case "fire":
                Debug.Log("FireSerch!!");
                hitFire();
                break;

            case "spider":
                Debug.Log("spiderHit");
                spiderBee();
                break;
            default:
                break;
        }
    }

    //火がエリアに侵入
    private void hitFire()
    {
        Vector3 _vec = erea.getHitPos();
        Vector3 _tecVec;
        _vec = _vec - this.transform.position;
        _tecVec.x = _vec.x; _tecVec.y = 0; _tecVec.z = _vec.z;
        //_tecVec.x =0; _tecVec.y = 0; _tecVec.z = -0.2f;

        //erea.transform.localPosition = _tecVec;
        transform.GetChild(1).gameObject.transform.position = this.transform.position + _tecVec.normalized * intervalSize * 50;
        //Debug.Log(_tecVec);

        calcFrontVec();
    }

    //ハチがエリアに侵入
    private void spiderBee()
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
}
