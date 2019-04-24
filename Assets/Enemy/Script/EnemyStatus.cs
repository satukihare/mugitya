using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    
    [SerializeField] private int maxHp = 10;        //　敵のMaxHP
    private int hp;//　敵のHP
    [SerializeField] private int attackPower = 1;   //　敵の攻撃力
    private EnemyMove enemy;
    private HPStatusUI hpStatusUI;                  //　敵のHPバー処理スクリプト

    void Start()
    {
        enemy = GetComponent<EnemyMove>();
        hpStatusUI = GetComponentInChildren<HPStatusUI>();
        hp = maxHp;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;

        //　HP表示用UIのアップデート
        hpStatusUI.UpdateHPValue();

        if (hp <= 0)
        {
            //　HP表示用UIを非表示にする
            hpStatusUI.SetDisable();
            enemy.Dead();
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }
}
