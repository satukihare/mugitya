using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMnger : MonoBehaviour {
    //虫のデータマップ
    IDictionary<string, int> bug_nums_map = new Dictionary<string, int>();
    //設置物のデータマップ
    IDictionary<string, int> installation_map = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start() {
        //虫のデータマップに予めタグと値をセット
        bug_nums_map.Add("bug_all_num", 0);
        bug_nums_map.Add("ant", 0);
        bug_nums_map.Add("bee", 0);
        bug_nums_map.Add("spider", 0);
        bug_nums_map.Add("mantis", 0);
        bug_nums_map.Add("hornet", 0);
        bug_nums_map.Add("locust", 0);

        //設置物に予めタグと値をセット
        installation_map.Add("wind", 0);
        installation_map.Add("fire", 0);
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

    public void addInstallationTag(string add_tag_name , int set_start_data)
    {
        installation_map.Add(add_tag_name, set_start_data);
    }
}
