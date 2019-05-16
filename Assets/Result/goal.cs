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

    private BugCount bugCountScript;

    //各虫のゴールした数用
    //[虫のゴールした数]
    //あり、ハチ、バッタ、蜘蛛、花
    public int[] goal_insect_num = new int[5];
    string[] goal_insect_name = { "ant","bee","locust","spider","flower" };

    public bool Is_ResultOn;


    // Start is called before the first frame update
    void Start()
    {
        bugCountScript = GameObject.Find("Main Camera").GetComponent<BugCount>();
        //初期化
        for (int i = 0; i < goal_insect_num.Length; i++)
        {
            goal_insect_num[i] = 0;
        }
        Is_ResultOn = false;


    }

    // Update is called once per frame
    void Update()
    {
        int Total_Bug = bugCountScript.totalBug;
        Debug.Log(Total_Bug);
        if (Total_Bug<=0 && Is_ResultOn==false)
        {
            Is_ResultOn = true;
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            GameObject.Find("gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
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
                Destroy(collision.gameObject);
                //消す処理
                //pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                //GameObject.Find("gameUI").SetActive(false);
                //Time.timeScale = 0f;
            }
        }
    }
}
