using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    GameObject player;                      //プレイヤーオブジェ取得
    public PlayerScript playerScript;       //プレイヤースクリプト取得
    public GameObject Petal1;
    public GameObject Petal2;
    public GameObject Petal3;
    public GameObject Petal4;
    public GameObject Petal5;

    public int Cnt;                         //ライフカウンター

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        Cnt = playerScript.SetLife();       //playerScriptからライフを取得
        Debug.Log(Cnt);
        Petal1 = GameObject.Find("Petal1");
        Petal2 = GameObject.Find("Petal2");
        Petal3 = GameObject.Find("Petal3");
        Petal4 = GameObject.Find("Petal4");
        Petal5 = GameObject.Find("Petal5");
        Petal1.SetActive(true);
        Petal2.SetActive(true);
        Petal3.SetActive(true);
        Petal4.SetActive(true);
        Petal5.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        Cnt = playerScript.SetLife();       //playerScriptからライフを取得
        if (Cnt == 5)
        {
            Petal1.SetActive(true);
            Petal2.SetActive(true);
            Petal3.SetActive(true);
            Petal4.SetActive(true);
            Petal5.SetActive(true);
        }
        if (Cnt == 4)
        {
            Petal1.SetActive(true);
            Petal2.SetActive(false);
            Petal3.SetActive(true);
            Petal4.SetActive(true);
            Petal5.SetActive(true);
        }
        if (Cnt == 3)
        {
            Petal1.SetActive(true);
            Petal2.SetActive(false);
            Petal3.SetActive(false);
            Petal4.SetActive(true);
            Petal5.SetActive(true);
        }
        if (Cnt == 2)
        {
            Petal1.SetActive(true);
            Petal2.SetActive(false);
            Petal3.SetActive(false);
            Petal4.SetActive(false);
            Petal5.SetActive(true);
        }
        if (Cnt == 1)
        {
            Petal1.SetActive(true);
            Petal2.SetActive(false);
            Petal3.SetActive(false);
            Petal4.SetActive(false);
            Petal5.SetActive(false);
        }
        if (Cnt == 0)
        {
            Petal1.SetActive(false);
            Petal2.SetActive(false);
            Petal3.SetActive(false);
            Petal4.SetActive(false);
            Petal5.SetActive(false);
        }


    }
}
