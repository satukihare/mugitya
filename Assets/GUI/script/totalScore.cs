using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalScore : MonoBehaviour {

    public Text text_obj = null;
    public gameMnger game_mnger = null;

    public int ant_point = 10;
    public int bee_point = 50;
    public int locust_point = 100;
    public int spider_point = 200;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        int tatal_score =
            (game_mnger.getGoalBugNums("ant") * ant_point) +
            (game_mnger.getGoalBugNums("bee") * bee_point) +
            (game_mnger.getGoalBugNums("locust") * locust_point) +
            (game_mnger.getGoalBugNums("spider") * spider_point);
        //テキストにセット
        text_obj.text = tatal_score.ToString();
    }
}
