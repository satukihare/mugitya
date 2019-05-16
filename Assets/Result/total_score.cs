using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class total_score : MonoBehaviour
{
    public Text mae_score;    //前のスコア表示
    Text my_score;            //自分のスコア
    int CountScore = 0;
    public GameObject goal_obj;             //ゴールオブジェ
    public int[] insect_goal = new int[5];         //ゴールした虫の数参照用
    public int[] insect_score = { 100, 500, 500, 1000, 5000 };    //各得点(ゴールした虫の数と一緒)
    public int total_score_ = 0;

    // Start is called before the first frame update
    void Start()
    {
        goal_obj = GameObject.Find("Cylinder");

        my_score = transform.GetComponent<Text>();//取得
        my_score.text = " Total " + 0 ;

        //ゴールした数呼び出し
        for (int i = 0; i < insect_goal.Length; i++)
        {
            insect_goal[i] = goal_obj.GetComponent<goal>().goal_insect_num[i];

            //合計得点計算
            total_score_ += insect_goal[i] * insect_score[i]; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mae_score.GetComponent<Score>().End_Score)
        {

            if (CountScore < total_score_)
            {
                CountScore +=100;
            }

            my_score.text = " Total " + CountScore;
        }
    }
}
