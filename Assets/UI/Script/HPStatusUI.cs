using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPStatusUI : MonoBehaviour
{
    private EnemyStatus enemyStatus;//　敵のステータス
    private Slider hpSlider;//　HP表示用スライダー

    void Start()
    {
        //　自身のルートに取り付けている敵のステータス取得
        enemyStatus = transform.root.GetComponent<EnemyStatus>();
        //　HP用Sliderを子要素から取得
        hpSlider = transform.Find("HPBar").GetComponent<Slider>();
        //　スライダーの値0～1の間になるように比率を計算
        hpSlider.value = (float)enemyStatus.GetMaxHp() / (float)enemyStatus.GetMaxHp();
    }

    // Update is called once per frame
    void Update()
    {
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
    }
    //　死んだらHPUIを非表示にする
    public void SetDisable()
    {
        gameObject.SetActive(false);
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)enemyStatus.GetHp() / (float)enemyStatus.GetMaxHp();
    }
}
