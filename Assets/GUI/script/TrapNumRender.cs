using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapNumRender : MonoBehaviour
{
    public Text text_obj = null;
    public gameMnger game_mnger = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //数値をセット
        string num_string = game_mnger.getInstallationNums(transform.tag).ToString();

        text_obj.text = "x" + num_string;
    }
}

