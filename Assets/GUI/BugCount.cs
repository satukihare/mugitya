using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugCount : MonoBehaviour
{
    GameObject[] tagObjects;

    float timer = 0.0f;
    float interval = 2.0f;
    private gameMnger gameManager;
    public int totalBug;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("gameMnger").GetComponent<gameMnger>();
        totalBug= Check("ant") + Check("bee")+ Check("spider")-3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Check("ant");
            Check("bee");
            Check("spider");
            Check("locust");
            totalBug = Check("ant") + Check("bee") + Check("spider")-3;
            timer = 0;
        }
        gameManager.setBugNums("ant", Check("ant") - 1);
        gameManager.setBugNums("bee", Check("bee") - 1);
        gameManager.setBugNums("spider", Check("spider") - 1);
        gameManager.setBugNums("locust", Check("locust") - 1);
        Debug.Log(totalBug);

    }

    //シーン上のBlockタグが付いたオブジェクトを数える
    public int Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        //Debug.Log(tagObjects.Length  + "  has  " + tagname); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
            //Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
        return tagObjects.Length;
    }
}
