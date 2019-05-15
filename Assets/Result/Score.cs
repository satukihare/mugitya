using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public bool bug_num;                    //自分が虫の数かどうか
    Text my_score;                   //自分のスコア表示用
    int CountScore;
    public Text maeScore;                   //上のスコア用
    int score;                     
    public bool End_Score;                  //処理が終わったか判定用
    public GameObject goal_obj;             //ゴールオブジェ
    int[] insect_goal = new int[5];         //ゴールした虫の数参照用
    public int insect_number;               //使いたい配列番号

    int[] insect_score = {100,500,500,1000, 5000};    //各得点(ゴールした虫の数と一緒)

    // Start is called before the first frame update
    void Start()
    {
        //ゴールした数呼び出し
        for (int i = 0; i < insect_goal.Length; i++)
        {
            insect_goal[i] = goal_obj.GetComponent<goal>().goal_insect_num[i];
        }
        //スコア計算
        score = insect_goal[insect_number] * insect_score[insect_number];

        //
        my_score = transform.GetComponent<Text>();

        End_Score = false;
        CountScore = 0;

        //虫の数の場合
        if (bug_num)
        {
            my_score.text = " x " + CountScore.ToString();
        }
        //スコアの場合
        else
        {
            my_score.text = " = " + CountScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //虫の数の場合
        if (bug_num)
        {
            //スコア処理が終わって次のスコア処理に入る || スコア処理のはじめ
            if (maeScore == null || maeScore.GetComponent<Score>().End_Score)
            {
                //参照したスコア分ぶんまわす
                if (CountScore < insect_goal[insect_number])
                {
                    CountScore ++;

                    if (CountScore >= insect_goal[insect_number])
                    {
                        End_Score = true;
                    }

                }

                my_score.text = " x " + CountScore.ToString();
            }
        }
        //スコアの場合
        if (!bug_num)
        {
            if (maeScore == null || maeScore.GetComponent<Score>().End_Score)
            {

                if (CountScore < score)
                {
                    CountScore += 10;

                    if (CountScore >= score)
                    {
                        End_Score = true;
                    }

                }

                my_score.text = " = " + CountScore.ToString();
            }
        }

    }
}
