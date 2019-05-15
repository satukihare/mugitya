using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;
  

    //各虫のゴールした数用
    //[虫のゴールした数]
    //あり、ハチ、バッタ、蜘蛛、花
    public int[] goal_insect_num = new int[5];
    string[] goal_insect_name = { "ant","bee","locust","spider","flower" };


    // Start is called before the first frame update
    void Start()
    {
        //初期化
        for (int i = 0; i < goal_insect_num.Length; i++)
        {
            goal_insect_num[i] = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //虫の数だけまわしてゴールした数と消す処理してる
        for (int i = 0; i < goal_insect_num.Length; i++)
        {
            if (collision.gameObject.tag == goal_insect_name[i])
            {
                //ゴールした！
                goal_insect_num[i]++;
                //消す処理
                pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                GameObject.Find("gameUI").SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
}
