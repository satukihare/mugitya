using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_result : MonoBehaviour
{
    public GameObject Icone;
    IconeMove icone_move;


    // Start is called before the first frame update
    void Start()
    {
        icone_move  =  Icone.GetComponent<IconeMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            //タイトルへ
            if (icone_move.IconPos == 1)
            {
                //時間動くようにする
                Time.timeScale = 1f;
                SceneManager.LoadScene("TitleScene");
            }
            //次のシーンへ
            if (icone_move.IconPos == 0)
            {
                //時間動くようにする
                Time.timeScale = 1f;
                SceneManager.LoadScene("");
            }
        }

    }
}
