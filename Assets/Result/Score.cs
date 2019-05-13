using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public bool bug_num;//自分が虫の数かどうか
    public Text my_score;//自分のスコア
    int CountScore;
    public Text maeScore; //上のスコア用
    public int kari_score;//各スコア判定用

    public bool End_Score;

    // Start is called before the first frame update
    void Start()
    {
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
            if (maeScore == null || maeScore.GetComponent<Score>().End_Score)
            {

                if (CountScore < kari_score)
                {
                    CountScore ++;

                    if (CountScore >= kari_score)
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

                if (CountScore < kari_score)
                {
                    CountScore += 10;

                    if (CountScore >= kari_score)
                    {
                        End_Score = true;
                    }

                }

                my_score.text = " = " + CountScore.ToString();
            }
        }

    }
}
