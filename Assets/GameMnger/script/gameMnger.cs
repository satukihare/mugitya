using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMnger : MonoBehaviour {
    //虫のデータマップ
    IDictionary<string, int> bug_nums_map = new Dictionary<string, int>();
    //設置物のデータマップ
    IDictionary<string, int> installation_map = new Dictionary<string, int>();
    //ゴールした虫の管理
    IDictionary<string, int> goal_bug_dictionary = new Dictionary<string, int>();

    //現在のゲームスピードを保存
    float game_speed = 1.0f;

    // Start is called before the first frame update
    void Start() {
        //虫のデータマップに予めタグと値をセット
        addBugTag("bug_all_num", 0);
        addBugTag("ant", 0);
        addBugTag("bee", 0);
        addBugTag("spider", 0);
        addBugTag("mantis", 0);
        addBugTag("hornet", 0);
        addBugTag("locust", 0);

        //設置物に予めタグと値をセット
        //addInstallationTag("wind", 0);
        //addInstallationTag("fire", 0);

        //ゴールした虫のタグを設定
        addGoalBugTag("bug_all_num", 0);
        addGoalBugTag("ant", 0);
        addGoalBugTag("bee", 0);
        addGoalBugTag("spider", 0);
        addGoalBugTag("mantis", 0);
        addGoalBugTag("hornet", 0);
        addGoalBugTag("locust", 0);

    }

    // Update is called once per frame
    void Update() {

    }

    //セットできたらtrueを返す
    public bool setBugNums(string set_tag_name, int set_num) {
        bool ret_flg = false;

        //タグがあるならセットする
        if (bug_nums_map.ContainsKey(set_tag_name)) {
            bug_nums_map[set_tag_name] = set_num;
            ret_flg = true;
        }
        return ret_flg;
    }
    //タグが存在しなかったら-1を返す
    public int getBugNums(string set_tag_name) {
        int rtn_num = -1;
        if (bug_nums_map.ContainsKey(set_tag_name))
            rtn_num = bug_nums_map[set_tag_name];
        return rtn_num;
    }
    //虫のタグを追加する
    public void addBugTag(string add_tag_name, int set_start_data) {
        if (!bug_nums_map.ContainsKey(add_tag_name))
            bug_nums_map.Add(add_tag_name, set_start_data);
        else
            bug_nums_map[add_tag_name] = set_start_data;
    }

    //セットできたらtrueを返す
    public bool setInstallationNums(string set_tag_name, int set_num) {
        bool ret_flg = false;

        //タグがあるならセットする
        if (installation_map.ContainsKey(set_tag_name)) {
            installation_map[set_tag_name] = set_num;
            ret_flg = true;
        }
        return ret_flg;
    }
    //タグが存在しなかったら-1を返す
    public int getInstallationNums(string set_tag_name) {
        int rtn_num = -1;
        if (installation_map.ContainsKey(set_tag_name))
            rtn_num = installation_map[set_tag_name];
        return rtn_num;
    }
    //トラップのタグを追加する
    public void addInstallationTag(string add_tag_name, int set_start_data) {

        if (!installation_map.ContainsKey(add_tag_name))
            installation_map.Add(add_tag_name, set_start_data);
        else
            installation_map[add_tag_name] = set_start_data;
    }

    //ゴールした虫の数を返す
    public int getGoalBugNums(string set_tag_naem) {
        int rtn_num = -1;
        if (goal_bug_dictionary.ContainsKey(set_tag_naem))
            rtn_num = goal_bug_dictionary[set_tag_naem];

        return rtn_num;
    }

    //ゴールした虫の数をインクリメントする
    public void incrementGoalBugNums(string set_tag_name) {
        if (goal_bug_dictionary.ContainsKey(set_tag_name))
            goal_bug_dictionary[set_tag_name]++;
    }
    //ゴールした虫の数をデクリメントする
    public void decrementGoalBugNums(string set_tag_name) {
        if (goal_bug_dictionary.ContainsKey(set_tag_name))
            goal_bug_dictionary[set_tag_name]--;
    }

    //タグを追加
    public void addGoalBugTag(string set_add_tag , int set_start_date ) {

        if (!goal_bug_dictionary.ContainsKey(set_add_tag))
            goal_bug_dictionary.Add(set_add_tag, set_start_date);
        else
            goal_bug_dictionary[set_add_tag] = set_start_date;
    }

    //ゲームスピードをセット
    public void setGameSpeed(float set_game_speed) {
        game_speed = set_game_speed;
    }

    //ゲームスピードを渡す
    public float getGameSpeed() {
        return game_speed;
    }
}
